namespace SchoolCMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CmsSettings : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CmsSettings",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        LayoutId = c.Int(nullable: false),
                        SchoolName = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Layouts", t => t.LayoutId, cascadeDelete: true)
                .Index(t => t.LayoutId);
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.CmsSettings", new[] { "LayoutId" });
            DropForeignKey("dbo.CmsSettings", "LayoutId", "dbo.Layouts");
            DropTable("dbo.CmsSettings");
        }
    }
}
