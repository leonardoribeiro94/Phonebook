namespace Phonebook.InfraStructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class db_phonebook_v1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CategoryGroup",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Descriptions = c.String(nullable: false, maxLength: 100, unicode: false),
                        Contact_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Contact", t => t.Contact_Id)
                .Index(t => t.Contact_Id);
            
            CreateTable(
                "dbo.ContactOwner",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name_FirstName = c.String(nullable: false, maxLength: 50),
                        Name_LastName = c.String(nullable: false, maxLength: 50),
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
                        ProfilePicture = c.String(maxLength: 1026),
                        Name_FirstName = c.String(nullable: false, maxLength: 50),
                        Name_LastName = c.String(nullable: false, maxLength: 50),
                        Email_Address = c.String(nullable: false, maxLength: 80),
                        PhoneNumber_Phone = c.String(nullable: false, maxLength: 50),
                        WebSite = c.String(nullable: false, maxLength: 50),
                        BirthDay = c.DateTime(nullable: false),
                        ContactOwner_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ContactOwner", t => t.ContactOwner_Id)
                .Index(t => t.ContactOwner_Id);
            
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
            DropForeignKey("dbo.CategoryGroup", "Contact_Id", "dbo.Contact");
            DropIndex("dbo.Contact", new[] { "ContactOwner_Id" });
            DropIndex("dbo.ContactOwner", new[] { "User_Id" });
            DropIndex("dbo.CategoryGroup", new[] { "Contact_Id" });
            DropTable("dbo.User");
            DropTable("dbo.Contact");
            DropTable("dbo.ContactOwner");
            DropTable("dbo.CategoryGroup");
        }
    }
}
