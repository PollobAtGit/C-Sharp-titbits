namespace CodeFirst.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class HasResignedAdd : DbMigration
    {
        public override void Up()
        {
            AddColumn("df-schema.employee-details", "HasResigned", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("df-schema.employee-details", "HasResigned");
        }
    }
}
