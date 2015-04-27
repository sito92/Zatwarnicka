namespace SchoolCMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PageChange1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.MenuButtons", "PageId", "dbo.Pages");
            DropForeignKey("dbo.Pages", "AuthorId", "dbo.Users");
            DropForeignKey("dbo.News", "TagId", "dbo.Tags");
            DropForeignKey("dbo.News", "AuthorId", "dbo.Users");
            DropIndex("dbo.MenuButtons", new[] { "PageId" });
            DropIndex("dbo.Pages", new[] { "AuthorId" });
            DropIndex("dbo.News", new[] { "TagId" });
            DropIndex("dbo.News", new[] { "AuthorId" });
            CreateTable(
                "dbo.InforamtionSources",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AuthorId = c.Int(nullable: false),
                        Title = c.String(),
                        Date = c.DateTime(nullable: false),
                        Content = c.String(),
                        TagId = c.Int(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.AuthorId, cascadeDelete: true)
                .ForeignKey("dbo.Tags", t => t.TagId, cascadeDelete: true)
                .Index(t => t.AuthorId)
                .Index(t => t.TagId);
            
            AddForeignKey("dbo.MenuButtons", "PageId", "dbo.InforamtionSources", "Id");
            CreateIndex("dbo.MenuButtons", "PageId");
            DropTable("dbo.Pages");
            DropTable("dbo.News");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.News",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TagId = c.Int(nullable: false),
                        AuthorId = c.Int(nullable: false),
                        Title = c.String(),
                        Date = c.DateTime(nullable: false),
                        Content = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Pages",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AuthorId = c.Int(nullable: false),
                        Title = c.String(),
                        Date = c.DateTime(nullable: false),
                        Content = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            DropIndex("dbo.InforamtionSources", new[] { "TagId" });
            DropIndex("dbo.InforamtionSources", new[] { "AuthorId" });
            DropIndex("dbo.MenuButtons", new[] { "PageId" });
            DropForeignKey("dbo.InforamtionSources", "TagId", "dbo.Tags");
            DropForeignKey("dbo.InforamtionSources", "AuthorId", "dbo.Users");
            DropForeignKey("dbo.MenuButtons", "PageId", "dbo.InforamtionSources");
            DropTable("dbo.InforamtionSources");
            CreateIndex("dbo.News", "AuthorId");
            CreateIndex("dbo.News", "TagId");
            CreateIndex("dbo.Pages", "AuthorId");
            CreateIndex("dbo.MenuButtons", "PageId");
            AddForeignKey("dbo.News", "AuthorId", "dbo.Users", "Id", cascadeDelete: true);
            AddForeignKey("dbo.News", "TagId", "dbo.Tags", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Pages", "AuthorId", "dbo.Users", "Id", cascadeDelete: true);
            AddForeignKey("dbo.MenuButtons", "PageId", "dbo.Pages", "Id");
        }
    }
}
