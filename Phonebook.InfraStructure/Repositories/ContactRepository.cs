using Phonebook.Domain.Command.Results;
using Phonebook.Domain.Entities;
using Phonebook.Domain.Repositories;
using Phonebook.InfraStructure.DataContexts;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Phonebook.InfraStructure.Repositories
{
    public class ContactRepository : IContactRepository
    {
        private readonly PhoneBookDataContext _context;

        public ContactRepository(PhoneBookDataContext context)
        {
            _context = context;
        }

        public bool EmailExists(string emailAddress)
        {
            return _context.Contacts
                    .AsNoTracking()
                    .Any(x => emailAddress.Equals(x.Email.Address));
        }

        public bool PhoneExists(string phoneNumber)
        {
            return _context.Contacts
                    .AsNoTracking()
                    .Any(x => phoneNumber.Equals(x.PhoneNumber.Phone));
        }

        public IEnumerable<CreateContactResult> Contacts()
        {
            return _context.Contacts
                .AsNoTracking()
                .OrderBy(x => x.Name)
                .Select(x => new CreateContactResult
                {
                    Id = x.Id,
                    Name = x.Name.FirstName,
                    Email = x.Email.Address,
                    PhoneNumber = x.PhoneNumber.Phone
                });
        }

        public CreateContactResult ContactsByName(string nameContact)
        {
            return _context.Contacts
                .AsNoTracking()
                .Select(x => new CreateContactResult
                {
                    Id = x.Id,
                    Name = x.Name.FirstName,
                    Email = x.Email.Address,
                    PhoneNumber = x.PhoneNumber.Phone
                })
                .FirstOrDefault(x => x.Name.Contains(nameContact));
        }

        public void Save(Contact contact)
        {
            _context.Contacts.Add(contact);
        }

        public void Update(Contact contact)
        {
            _context.Entry(contact).State = EntityState.Modified;
        }

        public void Delete(Guid id)
        {
            var contact = _context.Contacts
                           .AsNoTracking()
                           .FirstOrDefault(x => id.Equals(x.Id));

            _context.Entry(contact).State = EntityState.Deleted;
        }
    }
}
