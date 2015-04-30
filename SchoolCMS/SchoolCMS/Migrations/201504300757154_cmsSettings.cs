namespace SchoolCMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class cmsSettings : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Addresses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
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
            
            AddColumn("dbo.CmsSettings", "AdressId", c => c.Int(nullable: false));
            AddColumn("dbo.CmsSettings", "NewsAmountPerSite", c => c.Int(nullable: false));
            AddColumn("dbo.CmsSettings", "LogoSetingsId", c => c.Int());
            AddColumn("dbo.CmsSettings", "Address_Id", c => c.Int());
            AddColumn("dbo.CmsSettings", "LogoSettings_Id", c => c.Int());
            AddForeignKey("dbo.CmsSettings", "Address_Id", "dbo.Addresses", "Id");
            AddForeignKey("dbo.CmsSettings", "LogoSettings_Id", "dbo.LogoSettings", "Id");
            CreateIndex("dbo.CmsSettings", "Address_Id");
            CreateIndex("dbo.CmsSettings", "LogoSettings_Id");
        }
        
        public override void Down()
        {
            DropIndex("dbo.CmsSettings", new[] { "LogoSettings_Id" });
            DropIndex("dbo.CmsSettings", new[] { "Address_Id" });
            DropForeignKey("dbo.CmsSettings", "LogoSettings_Id", "dbo.LogoSettings");
            DropForeignKey("dbo.CmsSettings", "Address_Id", "dbo.Addresses");
            DropColumn("dbo.CmsSettings", "LogoSettings_Id");
            DropColumn("dbo.CmsSettings", "Address_Id");
            DropColumn("dbo.CmsSettings", "LogoSetingsId");
            DropColumn("dbo.CmsSettings", "NewsAmountPerSite");
            DropColumn("dbo.CmsSettings", "AdressId");
            DropTable("dbo.LogoSettings");
            DropTable("dbo.Addresses");
        }
    }
}
