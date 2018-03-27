using Phonebook.Shared.Commands;
using System;

namespace Phonebook.Domain.Command.Results
{
    public class CreateContactOwnerResult : ICommandResult
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAdress { get; set; }
    }
}
