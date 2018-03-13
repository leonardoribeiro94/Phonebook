using Phonebook.Domain.Command.Results;
using Phonebook.Domain.Entities;
using System;
using System.Collections.Generic;

namespace Phonebook.Domain.Repositories
{
    public interface IContactRepository
    {
        bool EmailExists(string emailAddress);
        bool PhoneExists(string phoneNumber);
        IEnumerable<CreateContactResult> Contacts();
        CreateContactResult ContactsByName(string nameContact);
        void Save(Contact contact);
        void Update(Contact contact);
        void Delete(Guid id);
    }
}
