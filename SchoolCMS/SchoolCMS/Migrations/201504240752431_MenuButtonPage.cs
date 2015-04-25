namespace SchoolCMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MenuButtonPage : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.MenuButtons", "PageId", c => c.Int());
            AddForeignKey("dbo.MenuButtons", "PageId", "dbo.Pages", "Id");
            CreateIndex("dbo.MenuButtons", "PageId");
        }
        
        public override void Down()
        {
            DropIndex("dbo.MenuButtons", new[] { "PageId" });
            DropForeignKey("dbo.MenuButtons", "PageId", "dbo.Pages");
            DropColumn("dbo.MenuButtons", "PageId");
        }
    }
}
