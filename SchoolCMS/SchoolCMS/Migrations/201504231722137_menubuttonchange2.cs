namespace SchoolCMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class menubuttonchange2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.MenuButtons", "Level", c => c.Int(nullable: false));
            DropColumn("dbo.MenuButtons", "IsLeap");
        }
        
        public override void Down()
        {
            AddColumn("dbo.MenuButtons", "IsLeap", c => c.Boolean(nullable: false));
            DropColumn("dbo.MenuButtons", "Level");
        }
    }
}
