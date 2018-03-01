using Phonebook.Domain.Entities;
using Phonebook.InfraStructure.Mappings;
using System.Data.Entity;

namespace Phonebook.InfraStructure.DataContexts
{
    public class PhoneBookDataContext : DbContext
    {
        public PhoneBookDataContext()
            : base("PhoneBookCnn")
        {
            Configuration.LazyLoadingEnabled = false;
            Configuration.ProxyCreationEnabled = false;
        }

        public DbSet<ContactOwner> ContactOwners { get; set; }
        public DbSet<Contact> Contacts { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new ContactOwnerMap());
            modelBuilder.Configurations.Add(new ContactMap());
            modelBuilder.Configurations.Add(new UserMap());
        }
    }
}
