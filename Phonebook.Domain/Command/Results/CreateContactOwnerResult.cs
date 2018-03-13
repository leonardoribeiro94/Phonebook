using Phonebook.Shared.Commands;
using System;

namespace Phonebook.Domain.Command.Results
{
    public class CreateContactOwnerResult : ICommandResult
    {
        public CreateContactOwnerResult()
        {

        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public string UserName { get; set; }
    }
}
