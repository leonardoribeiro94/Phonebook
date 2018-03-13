using Phonebook.Domain.ValueObjects;
using Phonebook.Shared.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Phonebook.Domain.Entities
{
    public class Contact : Entity
    {

        private readonly IList<CategoryGroup> _categoryGroups;

        public Contact()
        {

        }

        public Contact(Name name, PhoneNumber phoneNumber, Email email,
            string webSite, DateTime? birthDay, string profilePicture)
        {
            ProfilePicture = profilePicture;
            PhoneNumber = phoneNumber;
            Name = name;
            Email = email;
            WebSite = webSite;
            BirthDay = birthDay;
            _categoryGroups = new List<CategoryGroup>();

            AddNotifications(Name, Email, phoneNumber);
        }

        public string ProfilePicture { get; private set; }
        public Name Name { get; private set; }
        public Email Email { get; private set; }
        public PhoneNumber PhoneNumber { get; private set; }
        public string WebSite { get; private set; }
        public DateTime? BirthDay { get; private set; }
        public ICollection<CategoryGroup> CathegoryGroups => _categoryGroups.ToArray();

        public void AddCategoryGroup(CategoryGroup categoryGroup)
        {
            _categoryGroups.Add(categoryGroup);
        }

        public override string ToString()
        {
            return $"{Name.FirstName} {Name.LastName}";
        }
    }
}
