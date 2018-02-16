using System;
using System.Collections.Generic;
using System.Linq;

namespace Phonebook.Domain.Entities
{
    public class Contact
    {
        public Contact()
        {

        }

        private readonly IList<CategoryGroup> _categoryGroups;
        private readonly IList<CategoryPhone> _categoryPhones;

        public Contact(string firstName, string phone, string cellPhone, User user)
        {
            FirstName = firstName;
            Phone = phone;
            CellPhone = cellPhone;
            User = user;
            _categoryPhones = new List<CategoryPhone>();
            _categoryGroups = new List<CategoryGroup>();
        }

        public string ProfilePicture { get; set; }
        public string FirstName { get; private set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string WebSite { get; set; }
        public DateTime BirthDay { get; set; }
        public string Phone { get; private set; }
        public string CellPhone { get; private set; }
        public User User { get; private set; }
        public ICollection<CategoryPhone> CategoryPhones => _categoryPhones.ToArray();
        public ICollection<CategoryGroup> CathegoryGroups => _categoryGroups.ToArray();


        public void AddCategoryPhone(CategoryPhone categoryPhone)
        {
            _categoryPhones.Add(categoryPhone);
        }

        public void AddCategoryGroup(CategoryGroup categoryGroup)
        {
            _categoryGroups.Add(categoryGroup);
        }

    }
}
