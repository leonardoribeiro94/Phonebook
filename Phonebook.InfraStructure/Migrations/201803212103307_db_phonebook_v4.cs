namespace Phonebook.InfraStructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class db_phonebook_v4 : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.ContactOwner", name: "Name_FirstName", newName: "FirstName");
            RenameColumn(table: "dbo.ContactOwner", name: "Name_LastName", newName: "LastName");
            RenameColumn(table: "dbo.ContactOwner", name: "Email_Address", newName: "EmailAdress");
            AlterColumn("dbo.Contact", "WebSite", c => c.String(maxLength: 50));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Contact", "WebSite", c => c.String(nullable: false, maxLength: 50));
            RenameColumn(table: "dbo.ContactOwner", name: "EmailAdress", newName: "Email_Address");
            RenameColumn(table: "dbo.ContactOwner", name: "LastName", newName: "Name_LastName");
            RenameColumn(table: "dbo.ContactOwner", name: "FirstName", newName: "Name_FirstName");
        }
    }
}
