namespace EF_102.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Init992017 : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Categories", newName: "Category");
            RenameTable(name: "dbo.Items", newName: "Item");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.Item", newName: "Items");
            RenameTable(name: "dbo.Category", newName: "Categories");
        }
    }
}
