namespace CodeFirst.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class TPC : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "df-schema.OnlineCourse",
                c => new
                    {
                        CourseId = c.Int(nullable: false),
                        Name = c.String(),
                        Details = c.String(),
                        Trainer = c.String(),
                        URL = c.String(),
                    })
                .PrimaryKey(t => t.CourseId);
            
            CreateTable(
                "df-schema.OfflineCourse",
                c => new
                    {
                        CourseId = c.Int(nullable: false),
                        Name = c.String(),
                        Details = c.String(),
                        Trainer = c.String(),
                        Address = c.String(),
                    })
                .PrimaryKey(t => t.CourseId);
            
        }
        
        public override void Down()
        {
            DropTable("df-schema.OfflineCourse");
            DropTable("df-schema.OnlineCourse");
        }
    }
}
