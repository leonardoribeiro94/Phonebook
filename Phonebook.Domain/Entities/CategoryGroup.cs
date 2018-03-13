using Phonebook.Shared.Entities;
using System;

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
        public Guid ContactId { get; private set; }
        public Contact Contact { get; private set; }
    }
}