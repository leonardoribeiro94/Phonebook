using Phonebook.Shared.Commands;
using System;

namespace Phonebook.Domain.Command.Results
{
    public class CreateContactResult : ICommandResult
    {

        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
    }
}
