using Phonebook.Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace Phonebook.InfraStructure.Mappings
{
    public class ContactOwnerMap
        : EntityTypeConfiguration<ContactOwner>
    {
        public ContactOwnerMap()
        {
            ToTable("ContactOwner");
            HasKey(x => x.Id);

            Property(x => x.Name.FirstName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("FirstName");

            Property(x => x.Name.LastName)
                .HasMaxLength(50)
                .HasColumnName("LastName");

            Property(x => x.Email.Address)
                .IsRequired()
                .HasMaxLength(80)
                .HasColumnName("EmailAdress");

            HasMany(x => x.Contacts);
            HasRequired(x => x.User);
        }
    }
}
