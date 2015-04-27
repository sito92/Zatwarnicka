namespace SchoolCMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FilesChange : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.FileTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.FileInforamtionSources",
                c => new
                    {
                        File_Id = c.Int(nullable: false),
                        InforamtionSource_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.File_Id, t.InforamtionSource_Id })
                .ForeignKey("dbo.Files", t => t.File_Id, cascadeDelete: true)
                .ForeignKey("dbo.InforamtionSources", t => t.InforamtionSource_Id, cascadeDelete: true)
                .Index(t => t.File_Id)
                .Index(t => t.InforamtionSource_Id);
            
            AddColumn("dbo.Files", "FileName", c => c.String());
            AddColumn("dbo.Files", "Extension", c => c.String());
            AddColumn("dbo.Files", "Size", c => c.Int(nullable: false));
            AddColumn("dbo.Files", "CreateDateTime", c => c.DateTime(nullable: false));
            AddColumn("dbo.Files", "UploadDateTime", c => c.DateTime(nullable: false));
            AddColumn("dbo.Files", "FileTypeId", c => c.Int(nullable: false));
            AddForeignKey("dbo.Files", "FileTypeId", "dbo.FileTypes", "Id", cascadeDelete: true);
            CreateIndex("dbo.Files", "FileTypeId");
        }
        
        public override void Down()
        {
            DropIndex("dbo.FileInforamtionSources", new[] { "InforamtionSource_Id" });
            DropIndex("dbo.FileInforamtionSources", new[] { "File_Id" });
            DropIndex("dbo.Files", new[] { "FileTypeId" });
            DropForeignKey("dbo.FileInforamtionSources", "InforamtionSource_Id", "dbo.InforamtionSources");
            DropForeignKey("dbo.FileInforamtionSources", "File_Id", "dbo.Files");
            DropForeignKey("dbo.Files", "FileTypeId", "dbo.FileTypes");
            DropColumn("dbo.Files", "FileTypeId");
            DropColumn("dbo.Files", "UploadDateTime");
            DropColumn("dbo.Files", "CreateDateTime");
            DropColumn("dbo.Files", "Size");
            DropColumn("dbo.Files", "Extension");
            DropColumn("dbo.Files", "FileName");
            DropTable("dbo.FileInforamtionSources");
            DropTable("dbo.FileTypes");
        }
    }
}
