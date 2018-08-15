namespace Ch_11.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ItemNameIsRequired : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Items", "ItemName", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Items", "ItemName", c => c.String());
        }
    }
}
