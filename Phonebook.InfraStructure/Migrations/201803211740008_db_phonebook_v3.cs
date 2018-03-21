namespace Phonebook.InfraStructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class db_phonebook_v3 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ContactOwner", "CategoryGroup_Id", "dbo.CategoryGroup");
            DropIndex("dbo.ContactOwner", new[] { "CategoryGroup_Id" });
            DropColumn("dbo.ContactOwner", "CategoryGroup_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ContactOwner", "CategoryGroup_Id", c => c.Guid());
            CreateIndex("dbo.ContactOwner", "CategoryGroup_Id");
            AddForeignKey("dbo.ContactOwner", "CategoryGroup_Id", "dbo.CategoryGroup", "Id");
        }
    }
}
