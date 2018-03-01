using Phonebook.Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace Phonebook.InfraStructure.Mappings
{
    public class UserMap
        : EntityTypeConfiguration<User>
    {
        public UserMap()
        {
            ToTable("User");
            HasKey(x => x.Id);

            Property(x => x.UserName)
                .IsRequired().HasMaxLength(20);
            Property(x => x.Password)
                .IsRequired().HasMaxLength(20);
            Property(x => x.Active).IsRequired();
        }
    }
}
