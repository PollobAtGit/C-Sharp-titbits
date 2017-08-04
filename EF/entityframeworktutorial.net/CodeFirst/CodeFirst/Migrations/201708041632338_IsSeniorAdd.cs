namespace CodeFirst.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class IsSeniorAdd : DbMigration
    {
        public override void Up()
        {
            AddColumn("df-schema.Employee11", "IsSenior", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("df-schema.Employee11", "IsSenior");
        }
    }
}
