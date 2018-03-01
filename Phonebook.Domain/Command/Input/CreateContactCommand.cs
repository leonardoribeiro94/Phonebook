using Flunt.Notifications;
using Phonebook.Domain.Entities;
using Phonebook.Shared.Commands;
using System;
using System.Collections.Generic;

namespace Phonebook.Domain.Command.Input
{
    public class CreateContactCommand : Notifiable, ICommand
    {
        public string ProfilePicture { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public string WebSite { get; set; }
        public DateTime BirthDay { get; set; }
        public ICollection<CategoryGroup> CategoryGroups { get; set; }
    }
}
