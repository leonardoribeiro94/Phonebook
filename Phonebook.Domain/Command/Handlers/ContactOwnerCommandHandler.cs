using Flunt.Notifications;
using Phonebook.Domain.Command.Input;
using Phonebook.Domain.Command.Results;
using Phonebook.Domain.Entities;
using Phonebook.Domain.Repositories;
using Phonebook.Domain.ValueObjects;
using Phonebook.Shared.Commands;

namespace Phonebook.Domain.Command.Handlers
{
    public class ContactOwnerCommandHandler : Notifiable,
        ICommandHandler<CreateContactOwnerCommand>
    {
        private readonly IContactOwnerRepository _contactOwnerRepository;

        public ContactOwnerCommandHandler(IContactOwnerRepository contactOwnerRepository)
        {
            _contactOwnerRepository = contactOwnerRepository;
        }

        public ICommandResult Handle(CreateContactOwnerCommand command)
        {
            if (_contactOwnerRepository.UserExists(command.UserName))
            {
                AddNotification("UserName", "Este usuário já esta sendo ultilizado!");
                return null;
            }



            var name = new Name(command.FirstName, command.LastName);
            var email = new Email(command.Address);
            var user = new User(command.UserName, command.Password);
            var contactOwner = new ContactOwner(user, name, email);


            AddNotifications(name.Notifications);
            AddNotifications(email.Notifications);
            AddNotifications(user.Notifications);

            if (Invalid)
                return null;

            _contactOwnerRepository.Save(contactOwner);

            return new CreateContactOwnerResult(command.Id, contactOwner.Name.ToString());
        }
    }
}
