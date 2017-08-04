namespace CodeFirst.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EmployeeAdd : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "df-schema.employee",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        EmployeeName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "df-schema.employee-details",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Email = c.String(),
                        PhoneNumber = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("df-schema.employee", t => t.Id)
                .Index(t => t.Id);
            
            CreateTable(
                "df-schema.Employee11",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Salary = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("df-schema.employee-details", "Id", "df-schema.employee");
            DropIndex("df-schema.employee-details", new[] { "Id" });
            DropTable("df-schema.Employee11");
            DropTable("df-schema.employee-details");
            DropTable("df-schema.employee");
        }
    }
}
