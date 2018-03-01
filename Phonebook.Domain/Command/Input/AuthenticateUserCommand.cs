using Phonebook.Shared.Commands;

namespace Phonebook.Domain.Command.Input
{
    public class AuthenticateUserCommand : ICommand
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
