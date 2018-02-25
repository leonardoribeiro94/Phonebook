using Phonebook.Domain.Entities;

namespace Phonebook.Domain.Repositories
{
    public interface IContactRepository
    {
        bool PhoneExists();
        bool EmailExists();
        void Save(Contact contact);
    }
}
