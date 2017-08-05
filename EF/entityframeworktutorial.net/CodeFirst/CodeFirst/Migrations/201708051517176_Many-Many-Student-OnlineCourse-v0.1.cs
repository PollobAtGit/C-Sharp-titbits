namespace CodeFirst.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ManyManyStudentOnlineCoursev01 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "df-schema.StudentOnlineCourse",
                c => new
                    {
                        Student_StudentID = c.Int(nullable: false),
                        OnlineCourse_CourseId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Student_StudentID, t.OnlineCourse_CourseId })
                .ForeignKey("df-schema.Student", t => t.Student_StudentID, cascadeDelete: true)
                .ForeignKey("df-schema.OnlineCourse", t => t.OnlineCourse_CourseId, cascadeDelete: true)
                .Index(t => t.Student_StudentID)
                .Index(t => t.OnlineCourse_CourseId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("df-schema.StudentOnlineCourse", "OnlineCourse_CourseId", "df-schema.OnlineCourse");
            DropForeignKey("df-schema.StudentOnlineCourse", "Student_StudentID", "df-schema.Student");
            DropIndex("df-schema.StudentOnlineCourse", new[] { "OnlineCourse_CourseId" });
            DropIndex("df-schema.StudentOnlineCourse", new[] { "Student_StudentID" });
            DropTable("df-schema.StudentOnlineCourse");
        }
    }
}
