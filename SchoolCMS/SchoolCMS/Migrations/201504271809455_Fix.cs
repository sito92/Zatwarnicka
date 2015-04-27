namespace SchoolCMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Fix : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.MenuButtons", "PageId", "dbo.InforamtionSources");
            DropIndex("dbo.MenuButtons", new[] { "PageId" });
            AddColumn("dbo.MenuButtons", "InformationSourceId", c => c.Int());
            AddColumn("dbo.MenuButtons", "InforamtionSource_Id", c => c.Int());
            AddForeignKey("dbo.MenuButtons", "InforamtionSource_Id", "dbo.InforamtionSources", "Id");
            CreateIndex("dbo.MenuButtons", "InforamtionSource_Id");
            DropColumn("dbo.MenuButtons", "PageId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.MenuButtons", "PageId", c => c.Int());
            DropIndex("dbo.MenuButtons", new[] { "InforamtionSource_Id" });
            DropForeignKey("dbo.MenuButtons", "InforamtionSource_Id", "dbo.InforamtionSources");
            DropColumn("dbo.MenuButtons", "InforamtionSource_Id");
            DropColumn("dbo.MenuButtons", "InformationSourceId");
            CreateIndex("dbo.MenuButtons", "PageId");
            AddForeignKey("dbo.MenuButtons", "PageId", "dbo.InforamtionSources", "Id");
        }
    }
}
