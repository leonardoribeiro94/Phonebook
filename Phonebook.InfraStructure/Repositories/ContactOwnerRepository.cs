using Dapper;
using Phonebook.Domain.Command.Results;
using Phonebook.Domain.Entities;
using Phonebook.Domain.Repositories;
using Phonebook.InfraStructure.DataContexts;
using Phonebook.Shared;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;

namespace Phonebook.InfraStructure.Repositories
{
    public class ContactOwnerRepository : IContactOwnerRepository
    {
        private readonly PhoneBookDataContext _context;

        public ContactOwnerRepository(PhoneBookDataContext context)
        {
            _context = context;
        }

        public IEnumerable<CreateContactOwnerResult> Get()
        {
            const string sql = "SELECT * FROM dbo.ContactOwner";

            using (var conn = new SqlConnection(Runtime.ConnectionString))
            {
                return conn.Query<CreateContactOwnerResult>(sql);
            }

        }

        public ContactOwner GetById(Guid id)
        {
            return _context.ContactOwners
                    .Include(x => x.User)
                    .AsNoTracking()
                    .FirstOrDefault(x => id.Equals(x.Id));
        }

        public bool UserExists(string userName)
        {
            return _context.Users
                    .Any(x => userName.Equals(x.UserName));
        }

        public bool EmailExists(string emailAddress)
        {
            return _context.ContactOwners
                .AsNoTracking()
                .Any(x => emailAddress.Equals(x.Email.Address));
        }

        public void Save(ContactOwner contactOwner)
        {
            _context.ContactOwners.Add(contactOwner);
        }

        public void Update(ContactOwner contactOwner)
        {
            _context.Entry(contactOwner).State = EntityState.Modified;
        }

        public void ActivateAccount(string email)
        {
            var contactOwner = _context.ContactOwners
                                .Include(x => x.User)
                                .AsNoTracking()
                                .First(x => email.Equals(email));

            contactOwner.User.Activate();
        }

        public void DeactivateAccount(Guid id)
        {
            var contactOwner = _context.ContactOwners
                .Include(x => x.User)
                .AsNoTracking()
                .First(x => id.Equals(id));

            contactOwner.User.Deactivate();
        }
    }
}
