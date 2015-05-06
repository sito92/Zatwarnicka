namespace SchoolCMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class kolo : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.MenuButtons", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.InformationSources", "Title", c => c.String(nullable: false));
            AlterColumn("dbo.InformationSources", "Content", c => c.String(nullable: false));
            AlterColumn("dbo.Users", "Username", c => c.String(nullable: false));
            AlterColumn("dbo.Users", "Email", c => c.String(nullable: false));
            AlterColumn("dbo.Users", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.Users", "Surname", c => c.String(nullable: false));
            AlterColumn("dbo.Files", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.Files", "FileName", c => c.String(nullable: false));
            AlterColumn("dbo.Files", "Extension", c => c.String(nullable: false));
            AlterColumn("dbo.FileTypes", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.Tags", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.Layouts", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.Layouts", "Path", c => c.String(nullable: false));
            AlterColumn("dbo.Addresses", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.Addresses", "City", c => c.String(nullable: false));
            AlterColumn("dbo.Addresses", "Street", c => c.String(nullable: false));
            AlterColumn("dbo.Addresses", "PostCode", c => c.String(nullable: false));
            AlterColumn("dbo.LogoSettings", "LogoName", c => c.String(nullable: false));
            AlterColumn("dbo.LogoSettings", "LogoPath", c => c.String(nullable: false));
            AlterColumn("dbo.FileExtensions", "Extension", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.FileExtensions", "Extension", c => c.String());
            AlterColumn("dbo.LogoSettings", "LogoPath", c => c.String());
            AlterColumn("dbo.LogoSettings", "LogoName", c => c.String());
            AlterColumn("dbo.Addresses", "PostCode", c => c.String());
            AlterColumn("dbo.Addresses", "Street", c => c.String());
            AlterColumn("dbo.Addresses", "City", c => c.String());
            AlterColumn("dbo.Addresses", "Name", c => c.String());
            AlterColumn("dbo.Layouts", "Path", c => c.String());
            AlterColumn("dbo.Layouts", "Name", c => c.String());
            AlterColumn("dbo.Tags", "Name", c => c.String());
            AlterColumn("dbo.FileTypes", "Name", c => c.String());
            AlterColumn("dbo.Files", "Extension", c => c.String());
            AlterColumn("dbo.Files", "FileName", c => c.String());
            AlterColumn("dbo.Files", "Name", c => c.String());
            AlterColumn("dbo.Users", "Surname", c => c.String());
            AlterColumn("dbo.Users", "Name", c => c.String());
            AlterColumn("dbo.Users", "Email", c => c.String());
            AlterColumn("dbo.Users", "Username", c => c.String());
            AlterColumn("dbo.InformationSources", "Content", c => c.String());
            AlterColumn("dbo.InformationSources", "Title", c => c.String());
            AlterColumn("dbo.MenuButtons", "Name", c => c.String());
        }
    }
}
