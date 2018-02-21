using Phonebook.Domain.ValueObjects;
using Phonebook.Shared.Entities;

namespace Phonebook.Domain.Entities
{
    public class ContactOwner : Entity
    {
        public ContactOwner(User user, Name name)
        {
            User = user;
            Name = name;

            AddNotifications(Name, User);
        }

        public Name Name { get; private set; }
        public User User { get; private set; }

    }
}
