using Phonebook.Shared.Commands;
using System;

namespace Phonebook.Domain.Command.Results
{
    public class CreateContactOwnerResult : ICommandResult
    {
        public CreateContactOwnerResult()
        {

        }

        public CreateContactOwnerResult(Guid id, string name)
        {
            Id = Id;
            Name = name;
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}
