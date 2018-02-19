using Flunt.Notifications;
using Flunt.Validations;

namespace Phonebook.Domain.ValueObjects
{
    public class Email : Notifiable, IValidatable
    {
        public Email(string address)
        {
            Address = address;

        }
        public string Address { get; private set; }

        public void Validate()
        {
            AddNotifications(new Contract()
                .IsEmail(Address, "Email.Address", "E-mail inválido"));
        }
    }
}
