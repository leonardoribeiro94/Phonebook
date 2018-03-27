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

            Property(x => x.BirthDay).IsRequired();
            Property(x => x.ProfilePicture).HasMaxLength(1026);
            Property(x => x.Name.FirstName).IsRequired().HasMaxLength(50).HasColumnName("FirstName");
            Property(x => x.Name.LastName).IsRequired().HasMaxLength(50).HasColumnName("LastName");
            Property(x => x.PhoneNumber.Phone).IsRequired().HasMaxLength(50).HasColumnName("Phone");
            Property(x => x.WebSite).HasMaxLength(50);

            HasMany(x => x.CathegoryGroups)
                .WithRequired(x => x.Contact)
                .HasForeignKey(x => x.ContactId);
        }
    }
}
