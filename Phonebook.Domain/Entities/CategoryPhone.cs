using Flunt.Validations;
using Phonebook.Shared.Entities;

namespace Phonebook.Domain.Entities
{
    public class CategoryPhone : Entity
    {
        public CategoryPhone() { }

        public CategoryPhone(string description)
        {
            Description = description;

            AddNotifications(new Contract()
                .IsGreaterThan(description.Length, 100, "CategoryPhone.Description", "A descrição da categoria não pode ser maior que 100 caracteres"));
        }

        public string Description { get; private set; }
    }
}