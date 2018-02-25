using Flunt.Notifications;
using Phonebook.Shared.Commands;

namespace Phonebook.Domain.Command.Input
{
    public class CreateCathegoryPhoneCommand : Notifiable, ICommand
    {
        public string Description { get; set; }

        public void Validate()
        {

        }
    }
}
