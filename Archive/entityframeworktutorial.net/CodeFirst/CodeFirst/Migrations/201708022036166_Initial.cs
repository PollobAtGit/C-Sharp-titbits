namespace CodeFirst.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Standards",
                c => new
                    {
                        StandardID = c.Int(nullable: false, identity: true),
                        StandardName = c.String(),
                        Teacher_TeacherID = c.Int(),
                    })
                .PrimaryKey(t => t.StandardID)
                .ForeignKey("dbo.Teachers", t => t.Teacher_TeacherID)
                .Index(t => t.Teacher_TeacherID);
            
            CreateTable(
                "dbo.Students",
                c => new
                    {
                        StudentID = c.Int(nullable: false, identity: true),
                        StudentName = c.String(),
                        DateOfBirth = c.DateTime(),
                        Photo = c.Binary(),
                        Height = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Weight = c.Single(nullable: false),
                        Standard_StandardID = c.Int(),
                    })
                .PrimaryKey(t => t.StudentID)
                .ForeignKey("dbo.Standards", t => t.Standard_StandardID)
                .Index(t => t.Standard_StandardID);
            
            CreateTable(
                "dbo.Teachers",
                c => new
                    {
                        TeacherID = c.Int(nullable: false, identity: true),
                        TeacherName = c.String(),
                        Experience = c.Double(),
                        Designation = c.String(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.TeacherID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Standards", "Teacher_TeacherID", "dbo.Teachers");
            DropForeignKey("dbo.Students", "Standard_StandardID", "dbo.Standards");
            DropIndex("dbo.Students", new[] { "Standard_StandardID" });
            DropIndex("dbo.Standards", new[] { "Teacher_TeacherID" });
            DropTable("dbo.Teachers");
            DropTable("dbo.Students");
            DropTable("dbo.Standards");
        }
    }
}
