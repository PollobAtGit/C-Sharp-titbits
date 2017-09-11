namespace EF_102.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RequiredFieldInCategory : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Category", "Name", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Category", "Name");
        }
    }
}
