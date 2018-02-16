namespace Phonebook.Domain.Entities
{
    public class CategoryGroup
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