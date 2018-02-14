using System;
using System.Collections.Generic;

namespace Phonebook.Domain.Entities
{
    public class Contact
    {
        public string ProfilePicture { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string WebSite { get; set; }
        public DateTime BirthDay { get; set; }
        public string Phone { get; set; }
        public string CellPhone { get; set; }
        public IEnumerable<CategoryPhone> CategoryPhones { get; set; }
        public IEnumerable<CathegoryGroup> CathegoryGroups { get; set; }
    }
}
