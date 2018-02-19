namespace CodeFirst.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RenameSchema : DbMigration
    {
        public override void Up()
        {
            MoveTable(name: "dbo.Cooks", newSchema: "EFCodeFirst");
            MoveTable(name: "dbo.Printers", newSchema: "EFCodeFirst");
            MoveTable(name: "dbo.Rules", newSchema: "EFCodeFirst");
            MoveTable(name: "dbo.Standards", newSchema: "EFCodeFirst");
            MoveTable(name: "dbo.Students", newSchema: "EFCodeFirst");
            MoveTable(name: "dbo.Teachers", newSchema: "EFCodeFirst");
        }
        
        public override void Down()
        {
            MoveTable(name: "EFCodeFirst.Teachers", newSchema: "dbo");
            MoveTable(name: "EFCodeFirst.Students", newSchema: "dbo");
            MoveTable(name: "EFCodeFirst.Standards", newSchema: "dbo");
            MoveTable(name: "EFCodeFirst.Rules", newSchema: "dbo");
            MoveTable(name: "EFCodeFirst.Printers", newSchema: "dbo");
            MoveTable(name: "EFCodeFirst.Cooks", newSchema: "dbo");
        }
    }
}
