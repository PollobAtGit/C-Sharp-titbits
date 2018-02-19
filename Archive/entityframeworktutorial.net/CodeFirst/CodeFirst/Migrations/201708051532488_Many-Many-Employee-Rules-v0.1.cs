namespace CodeFirst.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ManyManyEmployeeRulesv01 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "df-schema.EmployeeSchedulingRule",
                c => new
                    {
                        Employee_Id = c.Int(nullable: false),
                        SchedulingRule_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Employee_Id, t.SchedulingRule_ID })
                .ForeignKey("df-schema.employee", t => t.Employee_Id, cascadeDelete: true)
                .ForeignKey("df-schema.Rule", t => t.SchedulingRule_ID, cascadeDelete: true)
                .Index(t => t.Employee_Id)
                .Index(t => t.SchedulingRule_ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("df-schema.EmployeeSchedulingRule", "SchedulingRule_ID", "df-schema.Rule");
            DropForeignKey("df-schema.EmployeeSchedulingRule", "Employee_Id", "df-schema.employee");
            DropIndex("df-schema.EmployeeSchedulingRule", new[] { "SchedulingRule_ID" });
            DropIndex("df-schema.EmployeeSchedulingRule", new[] { "Employee_Id" });
            DropTable("df-schema.EmployeeSchedulingRule");
        }
    }
}
