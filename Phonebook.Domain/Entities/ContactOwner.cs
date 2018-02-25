using Phonebook.Domain.ValueObjects;
using Phonebook.Shared.Entities;

namespace Phonebook.Domain.Entities
{
    public class ContactOwner : Entity
    {
        public ContactOwner() { }

        public ContactOwner(User user, Name name, Email email)
        {
            User = user;
            Name = name;
            Email = email;

            AddNotifications(Name, User, Email);
        }

        public Name Name { get; private set; }
        public User User { get; private set; }
        public Email Email { get; private set; }

    }
}
