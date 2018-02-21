using Phonebook.Shared.Entities;

namespace Phonebook.Domain.Entities
{
    public class CategoryPhone : Entity
    {
        public CategoryPhone()
        {

        }
        public CategoryPhone(string description)
        {
            Description = description;
        }

        public string Description { get; private set; }
    }
}