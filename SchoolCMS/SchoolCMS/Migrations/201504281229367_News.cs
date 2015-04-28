namespace SchoolCMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class News : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.InforamtionSources", "TagId", "dbo.Tags");
            DropIndex("dbo.InforamtionSources", new[] { "TagId" });
            AddForeignKey("dbo.InforamtionSources", "TagId", "dbo.Tags", "Id");
            CreateIndex("dbo.InforamtionSources", "TagId");
        }
        
        public override void Down()
        {
            DropIndex("dbo.InforamtionSources", new[] { "TagId" });
            DropForeignKey("dbo.InforamtionSources", "TagId", "dbo.Tags");
            CreateIndex("dbo.InforamtionSources", "TagId");
            AddForeignKey("dbo.InforamtionSources", "TagId", "dbo.Tags", "Id", cascadeDelete: true);
        }
    }
}
