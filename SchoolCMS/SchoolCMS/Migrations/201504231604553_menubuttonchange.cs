namespace SchoolCMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class menubuttonchange : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.MenuButtons", "IsRootButton", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.MenuButtons", "IsRootButton");
        }
    }
}
