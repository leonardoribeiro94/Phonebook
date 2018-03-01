using Phonebook.Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace Phonebook.InfraStructure.Mappings
{
    public class ContactMap
        : EntityTypeConfiguration<Contact>
    {
        public ContactMap()
        {
            ToTable("Contact");
            HasKey(x => x.Id);

            Property(x => x.Name.FirstName).IsRequired().HasMaxLength(50);
        }
    }
}
