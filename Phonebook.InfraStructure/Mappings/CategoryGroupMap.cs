using Phonebook.Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace Phonebook.InfraStructure.Mappings
{
    public class CategoryGroupMap :
        EntityTypeConfiguration<CategoryGroup>
    {
        public CategoryGroupMap()
        {
            ToTable("CategoryGroup");
            HasKey(x => x.Id);

            Property(x => x.Descriptions)
                .IsRequired().HasMaxLength(100).HasColumnType("varchar");
        }
    }
}
