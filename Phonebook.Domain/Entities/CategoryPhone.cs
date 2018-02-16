namespace Phonebook.Domain.Entities
{
    public class CategoryPhone
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