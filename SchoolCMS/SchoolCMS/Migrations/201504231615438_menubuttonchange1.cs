namespace SchoolCMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class menubuttonchange1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.MenuButtons", "IsLeap", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.MenuButtons", "IsLeap");
        }
    }
}
