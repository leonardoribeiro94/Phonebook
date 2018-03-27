using Phonebook.Domain.Entities;
using Phonebook.InfraStructure.Mappings;
using Phonebook.Shared;
using System.Data.Entity;

namespace Phonebook.InfraStructure.DataContexts
{
    public class PhoneBookDataContext : DbContext
    {
        public PhoneBookDataContext()
             : base(Runtime.ConnectionString)
        {
            Configuration.LazyLoadingEnabled = false;
            Configuration.ProxyCreationEnabled = false;
        }

        public DbSet<ContactOwner> ContactOwners { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<CategoryGroup> CategoryGroups { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new ContactOwnerMap());
            modelBuilder.Configurations.Add(new ContactMap());
            modelBuilder.Configurations.Add(new UserMap());
            modelBuilder.Configurations.Add(new CategoryGroupMap());
        }
    }
}
