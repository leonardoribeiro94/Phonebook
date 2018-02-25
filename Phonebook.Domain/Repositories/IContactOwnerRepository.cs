using Phonebook.Domain.Entities;
using System;

namespace Phonebook.Domain.Repositories
{
    public interface IContactOwnerRepository
    {
        ContactOwner Get(Guid id);
        ContactOwner GetById(Guid id);
        bool UserExists(string userName);
        void Save(ContactOwner contactOwner);
    }
}
