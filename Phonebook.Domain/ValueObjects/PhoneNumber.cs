using Flunt.Notifications;
using Flunt.Validations;

namespace Phonebook.Domain.ValueObjects
{
    public class PhoneNumber : Notifiable
    {
        public PhoneNumber(string phone)
        {
            Phone = phone;

            AddNotifications(new Contract()
                .Requires()
                .HasMinLen(Phone, 10, "PhoneNumber.Phone", "O telefone deve possuir no mínimo 10 caracteres")
                .HasMaxLen(Phone, 11, "PhoneNumber.Phone", "O telefone deve possuir no máximo 11 caracteres")
            );
        }

        public string Phone { get; private set; }
    }
}
