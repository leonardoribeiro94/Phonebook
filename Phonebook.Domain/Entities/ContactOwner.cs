using Phonebook.Domain.ValueObjects;
using Phonebook.Shared.Entities;
using System.Collections.Generic;
using System.Linq;

namespace Phonebook.Domain.Entities
{
    public class ContactOwner : Entity
    {
        public ContactOwner() { }

        private readonly IList<Contact> _contacts;

        public ContactOwner(User user, Name name, Email email)
        {
            User = user;
            Name = name;
            Email = email;
            _contacts = new List<Contact>();

            AddNotifications(Name, User, Email);
        }

        public Name Name { get; private set; }
        public User User { get; private set; }
        public Email Email { get; private set; }
        public ICollection<Contact> Contacts => _contacts.ToArray();

        public override string ToString() => $"{Name.FirstName} {Name.LastName}";

        public void AddItem(Contact contact)
        {
            if (contact.Valid)
            {
                AddNotifications(contact.Notifications);
                _contacts.Add(contact);
            }
        }
    }
}
