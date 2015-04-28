namespace SchoolCMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class News1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.InforamtionSources", "TagId", "dbo.Tags");
            DropIndex("dbo.InforamtionSources", new[] { "TagId" });
            AddColumn("dbo.Tags", "News_Id", c => c.Int());
            AddForeignKey("dbo.Tags", "News_Id", "dbo.InforamtionSources", "Id");
            CreateIndex("dbo.Tags", "News_Id");
            DropColumn("dbo.InforamtionSources", "TagId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.InforamtionSources", "TagId", c => c.Int());
            DropIndex("dbo.Tags", new[] { "News_Id" });
            DropForeignKey("dbo.Tags", "News_Id", "dbo.InforamtionSources");
            DropColumn("dbo.Tags", "News_Id");
            CreateIndex("dbo.InforamtionSources", "TagId");
            AddForeignKey("dbo.InforamtionSources", "TagId", "dbo.Tags", "Id");
        }
    }
}
