using Flunt.Notifications;
using Phonebook.Domain.Command.Input;
using Phonebook.Domain.Command.Results;
using Phonebook.Domain.Entities;
using Phonebook.Domain.Repositories;
using Phonebook.Domain.ValueObjects;
using Phonebook.Shared.Commands;

namespace Phonebook.Domain.Command.Handlers
{
    public class ContactCommandHandler : Notifiable, ICommandHandler<CreateContactCommand>
    {
        private readonly IContactRepository _contactRepository;

        public ContactCommandHandler(IContactRepository contactRepository)
        {
            _contactRepository = contactRepository;
        }

        public ICommandResult Handle(CreateContactCommand command)
        {

            if (_contactRepository.PhoneExists(command.PhoneNumber))
            {
                AddNotification("Phone", "Este telefone já está em uso!");
                return null;
            }

            var name = new Name(command.FirstName, command.LastName);
            var email = new Email(command.Address);
            var phoneNumber = new PhoneNumber(command.PhoneNumber);
            var webSite = command.WebSite;
            var birthDay = command.BirthDay;
            var profilePicture = command.ProfilePicture;
            var contact = new Contact(name, phoneNumber, email, webSite, birthDay, profilePicture);

            foreach (var cathegory in command.CategoryGroups)
            {
                var newCathegoryGroup = new CategoryGroup(cathegory.Descriptions);
                contact.AddCategoryGroup(newCathegoryGroup);
            }

            AddNotifications(name.Notifications);
            AddNotifications(email.Notifications);
            AddNotifications(phoneNumber.Notifications);
            AddNotifications(contact);

            if (Invalid)
                return null;

            _contactRepository.Save(contact);

            return new CreateContactResult();
        }
    }
}
