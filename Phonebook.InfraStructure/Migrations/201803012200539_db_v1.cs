namespace Phonebook.InfraStructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class db_v1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ContactOwner",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name_FirstName = c.String(nullable: false, maxLength: 50),
                        Name_LastName = c.String(maxLength: 50),
                        Email_Address = c.String(nullable: false, maxLength: 80),
                        User_Id = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.User", t => t.User_Id, cascadeDelete: true)
                .Index(t => t.User_Id);
            
            CreateTable(
                "dbo.Contact",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        ProfilePicture = c.String(),
                        Name_FirstName = c.String(nullable: false, maxLength: 50),
                        Name_LastName = c.String(maxLength: 50),
                        Email_Address = c.String(nullable: false, maxLength: 80),
                        PhoneNumber_Phone = c.String(),
                        WebSite = c.String(),
                        BirthDay = c.DateTime(),
                        ContactOwner_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ContactOwner", t => t.ContactOwner_Id)
                .Index(t => t.ContactOwner_Id);
            
            CreateTable(
                "dbo.CategoryGroups",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Descriptions = c.String(),
                        Contact_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Contact", t => t.Contact_Id)
                .Index(t => t.Contact_Id);
            
            CreateTable(
                "dbo.User",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 20),
                        Password = c.String(nullable: false, maxLength: 20),
                        Active = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ContactOwner", "User_Id", "dbo.User");
            DropForeignKey("dbo.Contact", "ContactOwner_Id", "dbo.ContactOwner");
            DropForeignKey("dbo.CategoryGroups", "Contact_Id", "dbo.Contact");
            DropIndex("dbo.CategoryGroups", new[] { "Contact_Id" });
            DropIndex("dbo.Contact", new[] { "ContactOwner_Id" });
            DropIndex("dbo.ContactOwner", new[] { "User_Id" });
            DropTable("dbo.User");
            DropTable("dbo.CategoryGroups");
            DropTable("dbo.Contact");
            DropTable("dbo.ContactOwner");
        }
    }
}
