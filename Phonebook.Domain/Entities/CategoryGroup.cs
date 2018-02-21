using Phonebook.Shared.Entities;

namespace Phonebook.Domain.Entities
{
    public class CategoryGroup : Entity
    {
        public CategoryGroup()
        {

        }
        public CategoryGroup(string descriptions)
        {
            Descriptions = descriptions;
        }

        public string Descriptions { get; private set; }
    }
}