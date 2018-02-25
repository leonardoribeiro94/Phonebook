using Phonebook.Shared.Commands;
using System;

namespace Phonebook.Domain.Command.Results
{
    public class CreateContactResult : ICommandResult
    {

        public CreateContactResult(Guid id, string name)
        {
            Id = id;
            Name = name;
        }

        public Guid Id { get; private set; }
        public string Name { get; private set; }
    }
}
