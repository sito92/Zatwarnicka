namespace SchoolCMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TagsNewsManyToMAny : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Tags", "News_Id", "dbo.InformationSources");
            DropIndex("dbo.Tags", new[] { "News_Id" });
            CreateTable(
                "dbo.TagNews",
                c => new
                    {
                        Tag_Id = c.Int(nullable: false),
                        News_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Tag_Id, t.News_Id })
                .ForeignKey("dbo.Tags", t => t.Tag_Id, cascadeDelete: true)
                .ForeignKey("dbo.InformationSources", t => t.News_Id, cascadeDelete: true)
                .Index(t => t.Tag_Id)
                .Index(t => t.News_Id);
            
            DropColumn("dbo.Tags", "News_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Tags", "News_Id", c => c.Int());
            DropIndex("dbo.TagNews", new[] { "News_Id" });
            DropIndex("dbo.TagNews", new[] { "Tag_Id" });
            DropForeignKey("dbo.TagNews", "News_Id", "dbo.InformationSources");
            DropForeignKey("dbo.TagNews", "Tag_Id", "dbo.Tags");
            DropTable("dbo.TagNews");
            CreateIndex("dbo.Tags", "News_Id");
            AddForeignKey("dbo.Tags", "News_Id", "dbo.InformationSources", "Id");
        }
    }
}
