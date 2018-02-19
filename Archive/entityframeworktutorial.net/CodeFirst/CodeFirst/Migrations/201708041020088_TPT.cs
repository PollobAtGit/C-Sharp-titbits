namespace CodeFirst.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TPT : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "df-schema.OfflineCourse", newName: "Offline-Course");
            RenameTable(name: "df-schema.OnlineCourse", newName: "Online-Course");
            CreateTable(
                "df-schema.base_course",
                c => new
                    {
                        CourseId = c.Int(nullable: false),
                        Name = c.String(),
                        Details = c.String(),
                        Trainer = c.String(),
                    })
                .PrimaryKey(t => t.CourseId);
            
        }
        
        public override void Down()
        {
            DropTable("df-schema.base_course");
            RenameTable(name: "df-schema.Online-Course", newName: "OnlineCourse");
            RenameTable(name: "df-schema.Offline-Course", newName: "OfflineCourse");
        }
    }
}
