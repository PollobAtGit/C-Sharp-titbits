namespace CodeFirst.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class DefaultSchemaName : DbMigration
    {
        public override void Up()
        {
            MoveTable(name: "dbo.Cooks", newSchema: "df-schema");
            MoveTable(name: "dbo.Printers", newSchema: "df-schema");
            MoveTable(name: "dbo.Rules", newSchema: "df-schema");
            MoveTable(name: "dbo.Standards", newSchema: "df-schema");
            MoveTable(name: "dbo.Students", newSchema: "df-schema");
            MoveTable(name: "dbo.Teachers", newSchema: "df-schema");
        }
        
        public override void Down()
        {
            MoveTable(name: "df-schema.Teachers", newSchema: "dbo");
            MoveTable(name: "df-schema.Students", newSchema: "dbo");
            MoveTable(name: "df-schema.Standards", newSchema: "dbo");
            MoveTable(name: "df-schema.Rules", newSchema: "dbo");
            MoveTable(name: "df-schema.Printers", newSchema: "dbo");
            MoveTable(name: "df-schema.Cooks", newSchema: "dbo");
        }
    }
}
