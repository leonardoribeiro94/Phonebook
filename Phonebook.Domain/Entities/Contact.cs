using Flunt.Notifications;
using Phonebook.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Phonebook.Domain.Entities
{
    public class Contact : Notifiable
    {

        private readonly IList<CategoryGroup> _categoryGroups;

        public Contact()
        {

        }
        public Contact(Name name, User user, PhoneNumber phoneNumber, Email email)
        {

            User = user;
            PhoneNumber = phoneNumber;
            Name = name;
            Email = email;
            _categoryGroups = new List<CategoryGroup>();

            AddNotifications(Name, Email, phoneNumber);
        }

        public string ProfilePicture { get; set; }
        public Name Name { get; private set; }
        public Email Email { get; set; }
        public PhoneNumber PhoneNumber { get; private set; }
        public string WebSite { get; set; }
        public DateTime BirthDay { get; set; }
        public User User { get; private set; }
        public CategoryPhone CategoryPhone { get; set; }
        public ICollection<CategoryGroup> CathegoryGroups => _categoryGroups.ToArray();


        public void AddCategoryGroup(CategoryGroup categoryGroup)
        {
            _categoryGroups.Add(categoryGroup);
        }

    }
}
