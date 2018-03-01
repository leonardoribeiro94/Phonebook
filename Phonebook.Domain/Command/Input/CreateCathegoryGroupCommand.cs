using Phonebook.Shared.Commands;

namespace Phonebook.Domain.Command.Input
{
    public class CreateCathegoryGroupCommand : ICommand
    {
        public string Description { get; set; }

    }
}
