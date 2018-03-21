namespace Phonebook.InfraStructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class db_phonebook_v2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.CategoryGroup", "Contact_Id", "dbo.Contact");
            DropIndex("dbo.CategoryGroup", new[] { "Contact_Id" });
            RenameColumn(table: "dbo.Contact", name: "Name_FirstName", newName: "FirstName");
            RenameColumn(table: "dbo.Contact", name: "Name_LastName", newName: "LastName");
            RenameColumn(table: "dbo.Contact", name: "PhoneNumber_Phone", newName: "Phone");
            RenameColumn(table: "dbo.CategoryGroup", name: "Contact_Id", newName: "ContactId");
            AddColumn("dbo.ContactOwner", "CategoryGroup_Id", c => c.Guid());
            AlterColumn("dbo.CategoryGroup", "ContactId", c => c.Guid(nullable: false));
            CreateIndex("dbo.CategoryGroup", "ContactId");
            CreateIndex("dbo.ContactOwner", "CategoryGroup_Id");
            AddForeignKey("dbo.ContactOwner", "CategoryGroup_Id", "dbo.CategoryGroup", "Id");
            AddForeignKey("dbo.CategoryGroup", "ContactId", "dbo.Contact", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CategoryGroup", "ContactId", "dbo.Contact");
            DropForeignKey("dbo.ContactOwner", "CategoryGroup_Id", "dbo.CategoryGroup");
            DropIndex("dbo.ContactOwner", new[] { "CategoryGroup_Id" });
            DropIndex("dbo.CategoryGroup", new[] { "ContactId" });
            AlterColumn("dbo.CategoryGroup", "ContactId", c => c.Guid());
            DropColumn("dbo.ContactOwner", "CategoryGroup_Id");
            RenameColumn(table: "dbo.CategoryGroup", name: "ContactId", newName: "Contact_Id");
            RenameColumn(table: "dbo.Contact", name: "Phone", newName: "PhoneNumber_Phone");
            RenameColumn(table: "dbo.Contact", name: "LastName", newName: "Name_LastName");
            RenameColumn(table: "dbo.Contact", name: "FirstName", newName: "Name_FirstName");
            CreateIndex("dbo.CategoryGroup", "Contact_Id");
            AddForeignKey("dbo.CategoryGroup", "Contact_Id", "dbo.Contact", "Id");
        }
    }
}
