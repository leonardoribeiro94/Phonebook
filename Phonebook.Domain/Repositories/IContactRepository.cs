using Phonebook.Domain.Entities;
using System;

namespace Phonebook.Domain.Repositories
{
    public interface IContactRepository
    {
        bool EmailExists(string emailAddress);
        bool PhoneExists(string phoneNumber);
        void Save(Contact contact);
        void Update(Contact contact);
        void Delete(Guid id);
    }
}
