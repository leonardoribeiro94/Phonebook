using Flunt.Notifications;
using Flunt.Validations;

namespace Phonebook.Domain.ValueObjects
{
    public class Name : Notifiable
    {
        public Name(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
            AddNotifications(new Contract()
                .Requires()
                .IsNullOrEmpty(FirstName, "Name.FirstName", "O Nome deve ser preenchido")
                .HasMinLen(FirstName, 3, "Name.FirstName", "O Nome deve possuir pelo menos 3 caracteres")
                .HasMaxLen(FirstName, 50, "Name.FirstName", "O Nome deve ter no máximo 50 caracteres")
                .IsGreaterThan(LastName.Length, 50, "Name.LastName", "O Sobrenome deve ter no máximo 50 caracteres"));

        }

        public string FirstName { get; private set; }
        public string LastName { get; private set; }

    }
}
