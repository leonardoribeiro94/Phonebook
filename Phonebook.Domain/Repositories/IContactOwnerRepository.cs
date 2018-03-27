using Phonebook.Domain.Command.Results;
using Phonebook.Domain.Entities;
using System;
using System.Collections.Generic;

namespace Phonebook.Domain.Repositories
{
    public interface IContactOwnerRepository
    {
        IEnumerable<CreateContactOwnerResult> Get();
        ContactOwner GetById(Guid id);
        bool UserExists(string userName);
        void Save(ContactOwner contactOwner);
        void Update(ContactOwner contactOwner);
        void ActivateAccount(string email);
        void DeactivateAccount(Guid id);
    }
}
