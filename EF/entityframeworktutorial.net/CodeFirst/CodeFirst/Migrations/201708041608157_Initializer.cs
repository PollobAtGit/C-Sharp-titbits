namespace CodeFirst.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initializer : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "df-schema.Cooks", newName: "Cook");
            RenameTable(name: "df-schema.Printers", newName: "Printer");
            RenameTable(name: "df-schema.Rules", newName: "Rule");
            RenameTable(name: "df-schema.Standards", newName: "Standard");
            RenameTable(name: "df-schema.Students", newName: "Student");
            RenameTable(name: "df-schema.Teachers", newName: "Teacher");
        }
        
        public override void Down()
        {
            RenameTable(name: "df-schema.Teacher", newName: "Teachers");
            RenameTable(name: "df-schema.Student", newName: "Students");
            RenameTable(name: "df-schema.Standard", newName: "Standards");
            RenameTable(name: "df-schema.Rule", newName: "Rules");
            RenameTable(name: "df-schema.Printer", newName: "Printers");
            RenameTable(name: "df-schema.Cook", newName: "Cooks");
        }
    }
}
