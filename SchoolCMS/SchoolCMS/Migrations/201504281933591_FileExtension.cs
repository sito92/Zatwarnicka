namespace SchoolCMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FileExtension : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.FileExtensions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Extension = c.String(),
                        FileTypeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.FileTypes", t => t.FileTypeId, cascadeDelete: true)
                .Index(t => t.FileTypeId);
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.FileExtensions", new[] { "FileTypeId" });
            DropForeignKey("dbo.FileExtensions", "FileTypeId", "dbo.FileTypes");
            DropTable("dbo.FileExtensions");
        }
    }
}
