namespace SchoolCMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MenuButtonPage1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.MenuButtons", "PageId", c => c.Int());
            AddForeignKey("dbo.MenuButtons", "PageId", "dbo.InforamtionSources", "Id");
            CreateIndex("dbo.MenuButtons", "PageId");
        }
        
        public override void Down()
        {
            DropIndex("dbo.MenuButtons", new[] { "PageId" });
            DropForeignKey("dbo.MenuButtons", "PageId", "dbo.InforamtionSources");
            DropColumn("dbo.MenuButtons", "PageId");
        }
    }
}
