namespace SchoolCMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class menubuttonchange3 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.MenuButtons", "ParentId", c => c.Int());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.MenuButtons", "ParentId", c => c.Int(nullable: false));
        }
    }
}
