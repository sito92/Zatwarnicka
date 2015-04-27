namespace SchoolCMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreatedatetimeRemoved : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Files", "CreateDateTime");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Files", "CreateDateTime", c => c.DateTime(nullable: false));
        }
    }
}
