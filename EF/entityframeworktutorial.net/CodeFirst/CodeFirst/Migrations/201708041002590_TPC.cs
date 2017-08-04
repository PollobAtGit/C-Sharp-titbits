namespace CodeFirst.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TPC : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "df-schema.Rules", newName: "AssemblyRule");
            DropPrimaryKey("df-schema.AssemblyRule");
            CreateTable(
                "df-schema.SchedulingRule",
                c => new
                    {
                        ID = c.Int(nullable: false),
                        Importance = c.Int(nullable: false),
                        ApplicableToTeacher = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            AlterColumn("df-schema.AssemblyRule", "ID", c => c.Int(nullable: false));
            AddPrimaryKey("df-schema.AssemblyRule", "ID");
            DropColumn("df-schema.AssemblyRule", "ApplicableToTeacher");
            DropColumn("df-schema.AssemblyRule", "Discriminator");
        }
        
        public override void Down()
        {
            AddColumn("df-schema.AssemblyRule", "Discriminator", c => c.String(nullable: false, maxLength: 128));
            AddColumn("df-schema.AssemblyRule", "ApplicableToTeacher", c => c.String());
            DropPrimaryKey("df-schema.AssemblyRule");
            AlterColumn("df-schema.AssemblyRule", "ID", c => c.Int(nullable: false, identity: true));
            DropTable("df-schema.SchedulingRule");
            AddPrimaryKey("df-schema.AssemblyRule", "ID");
            RenameTable(name: "df-schema.AssemblyRule", newName: "Rules");
        }
    }
}
