namespace SchoolCMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ostatniamigracja : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.MenuButtons",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        IsRootButton = c.Boolean(nullable: false),
                        Level = c.Int(nullable: false),
                        ParentId = c.Int(),
                        InformationSourceId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.InformationSources", t => t.InformationSourceId)
                .ForeignKey("dbo.MenuButtons", t => t.ParentId)
                .Index(t => t.InformationSourceId)
                .Index(t => t.ParentId);
            
            CreateTable(
                "dbo.InformationSources",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AuthorId = c.Int(nullable: false),
                        Title = c.String(),
                        Date = c.DateTime(nullable: false),
                        Content = c.String(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.AuthorId, cascadeDelete: true)
                .Index(t => t.AuthorId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Username = c.String(),
                        Email = c.String(),
                        Name = c.String(),
                        Surname = c.String(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Files",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        FileName = c.String(),
                        Extension = c.String(),
                        Size = c.Int(nullable: false),
                        UploadDateTime = c.DateTime(nullable: false),
                        FileTypeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.FileTypes", t => t.FileTypeId, cascadeDelete: true)
                .Index(t => t.FileTypeId);
            
            CreateTable(
                "dbo.FileTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Tags",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        News_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.InformationSources", t => t.News_Id)
                .Index(t => t.News_Id);
            
            CreateTable(
                "dbo.Layouts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Path = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.CmsSettings",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        LayoutId = c.Int(nullable: false),
                        SchoolName = c.String(),
                        AdressId = c.Int(nullable: false),
                        NewsAmountPerSite = c.Int(nullable: false),
                        LogoSetingsId = c.Int(),
                        Address_Id = c.Int(),
                        LogoSettings_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Layouts", t => t.LayoutId, cascadeDelete: true)
                .ForeignKey("dbo.Addresses", t => t.Address_Id)
                .ForeignKey("dbo.LogoSettings", t => t.LogoSettings_Id)
                .Index(t => t.LayoutId)
                .Index(t => t.Address_Id)
                .Index(t => t.LogoSettings_Id);
            
            CreateTable(
                "dbo.Addresses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        City = c.String(),
                        Street = c.String(),
                        HouseNumber = c.Int(nullable: false),
                        PostCode = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.LogoSettings",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        LogoName = c.String(),
                        LogoPath = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
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
            
            CreateTable(
                "dbo.FileInformationSources",
                c => new
                    {
                        File_Id = c.Int(nullable: false),
                        InformationSource_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.File_Id, t.InformationSource_Id })
                .ForeignKey("dbo.Files", t => t.File_Id, cascadeDelete: true)
                .ForeignKey("dbo.InformationSources", t => t.InformationSource_Id, cascadeDelete: true)
                .Index(t => t.File_Id)
                .Index(t => t.InformationSource_Id);
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.FileInformationSources", new[] { "InformationSource_Id" });
            DropIndex("dbo.FileInformationSources", new[] { "File_Id" });
            DropIndex("dbo.FileExtensions", new[] { "FileTypeId" });
            DropIndex("dbo.CmsSettings", new[] { "LogoSettings_Id" });
            DropIndex("dbo.CmsSettings", new[] { "Address_Id" });
            DropIndex("dbo.CmsSettings", new[] { "LayoutId" });
            DropIndex("dbo.Tags", new[] { "News_Id" });
            DropIndex("dbo.Files", new[] { "FileTypeId" });
            DropIndex("dbo.InformationSources", new[] { "AuthorId" });
            DropIndex("dbo.MenuButtons", new[] { "ParentId" });
            DropIndex("dbo.MenuButtons", new[] { "InformationSourceId" });
            DropForeignKey("dbo.FileInformationSources", "InformationSource_Id", "dbo.InformationSources");
            DropForeignKey("dbo.FileInformationSources", "File_Id", "dbo.Files");
            DropForeignKey("dbo.FileExtensions", "FileTypeId", "dbo.FileTypes");
            DropForeignKey("dbo.CmsSettings", "LogoSettings_Id", "dbo.LogoSettings");
            DropForeignKey("dbo.CmsSettings", "Address_Id", "dbo.Addresses");
            DropForeignKey("dbo.CmsSettings", "LayoutId", "dbo.Layouts");
            DropForeignKey("dbo.Tags", "News_Id", "dbo.InformationSources");
            DropForeignKey("dbo.Files", "FileTypeId", "dbo.FileTypes");
            DropForeignKey("dbo.InformationSources", "AuthorId", "dbo.Users");
            DropForeignKey("dbo.MenuButtons", "ParentId", "dbo.MenuButtons");
            DropForeignKey("dbo.MenuButtons", "InformationSourceId", "dbo.InformationSources");
            DropTable("dbo.FileInformationSources");
            DropTable("dbo.FileExtensions");
            DropTable("dbo.LogoSettings");
            DropTable("dbo.Addresses");
            DropTable("dbo.CmsSettings");
            DropTable("dbo.Layouts");
            DropTable("dbo.Tags");
            DropTable("dbo.FileTypes");
            DropTable("dbo.Files");
            DropTable("dbo.Users");
            DropTable("dbo.InformationSources");
            DropTable("dbo.MenuButtons");
        }
    }
}
