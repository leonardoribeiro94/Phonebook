using Phonebook.Shared.Commands;

namespace Phonebook.Domain.Command.Input
{
    public class CreateCathegoryGroup : ICommand
    {
        public string Description { get; set; }

        public void Validate()
        {

        }
    }
}
