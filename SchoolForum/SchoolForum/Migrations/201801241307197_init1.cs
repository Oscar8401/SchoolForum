namespace SchoolForum.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Messages",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false, maxLength: 30),
                        Text = c.String(nullable: false, maxLength: 300),
                        PostingDate = c.DateTime(nullable: false),
                        NumberOfMessage = c.Int(nullable: false),
                        categories_Id = c.Int(),
                        users_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Categories", t => t.categories_Id)
                .ForeignKey("dbo.AspNetUsers", t => t.users_Id)
                .Index(t => t.categories_Id)
                .Index(t => t.users_Id);
            
            CreateTable(
                "dbo.Replies",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TextReply = c.String(),
                        ReplyingDate = c.DateTime(nullable: false),
                        userReply = c.String(),
                        NumberOfReply = c.Int(nullable: false),
                        messages_Id = c.Int(),
                        users_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Messages", t => t.messages_Id)
                .ForeignKey("dbo.AspNetUsers", t => t.users_Id)
                .Index(t => t.messages_Id)
                .Index(t => t.users_Id);
            
            CreateTable(
                "dbo.CategoriesViewModels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                        Members = c.String(),
                        MemebersCount = c.Int(nullable: false),
                        NumberOfMessages = c.Int(nullable: false),
                        CreatingTime = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        User = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.MessagesViewModels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Text = c.String(),
                        NumberOfMessages = c.Int(nullable: false),
                        User = c.String(),
                        PostingDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        CategoryName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ApplicationUserCategories",
                c => new
                    {
                        ApplicationUser_Id = c.String(nullable: false, maxLength: 128),
                        Categories_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.ApplicationUser_Id, t.Categories_Id })
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUser_Id, cascadeDelete: true)
                .ForeignKey("dbo.Categories", t => t.Categories_Id, cascadeDelete: true)
                .Index(t => t.ApplicationUser_Id)
                .Index(t => t.Categories_Id);
            
            AddColumn("dbo.Categories", "CreatingTime", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
            AddColumn("dbo.AspNetUsers", "Age", c => c.Int(nullable: false));
            AddColumn("dbo.AspNetUsers", "Role", c => c.String());
            AddColumn("dbo.AspNetUsers", "MembersCount", c => c.Int(nullable: false));
            AlterColumn("dbo.Categories", "Name", c => c.String(nullable: false, maxLength: 30));
            AlterColumn("dbo.AspNetUsers", "FirstName", c => c.String(nullable: false, maxLength: 50));
            DropColumn("dbo.AspNetUsers", "DateOfBirth");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AspNetUsers", "DateOfBirth", c => c.String());
            DropForeignKey("dbo.Replies", "users_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Messages", "users_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.ApplicationUserCategories", "Categories_Id", "dbo.Categories");
            DropForeignKey("dbo.ApplicationUserCategories", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Replies", "messages_Id", "dbo.Messages");
            DropForeignKey("dbo.Messages", "categories_Id", "dbo.Categories");
            DropIndex("dbo.ApplicationUserCategories", new[] { "Categories_Id" });
            DropIndex("dbo.ApplicationUserCategories", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.Replies", new[] { "users_Id" });
            DropIndex("dbo.Replies", new[] { "messages_Id" });
            DropIndex("dbo.Messages", new[] { "users_Id" });
            DropIndex("dbo.Messages", new[] { "categories_Id" });
            AlterColumn("dbo.AspNetUsers", "FirstName", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.Categories", "Name", c => c.String(nullable: false, maxLength: 50));
            DropColumn("dbo.AspNetUsers", "MembersCount");
            DropColumn("dbo.AspNetUsers", "Role");
            DropColumn("dbo.AspNetUsers", "Age");
            DropColumn("dbo.Categories", "CreatingTime");
            DropTable("dbo.ApplicationUserCategories");
            DropTable("dbo.MessagesViewModels");
            DropTable("dbo.CategoriesViewModels");
            DropTable("dbo.Replies");
            DropTable("dbo.Messages");
        }
    }
}
