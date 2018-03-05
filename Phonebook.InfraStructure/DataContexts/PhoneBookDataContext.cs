using Phonebook.Domain.Entities;
using Phonebook.InfraStructure.Mappings;
using System.Data.Entity;

namespace Phonebook.InfraStructure.DataContexts
{
    public class PhoneBookDataContext : DbContext
    {
        private static readonly string phoneBookStr =
            @"Server=.\SQLEXPRESS2008R2;Database=PhoneBook;User Id=sa;Password = 1234567890;";

        public PhoneBookDataContext()
            : base(phoneBookStr)
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
