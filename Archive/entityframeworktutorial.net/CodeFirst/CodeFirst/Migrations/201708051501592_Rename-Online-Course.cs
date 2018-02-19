namespace CodeFirst.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RenameOnlineCourse : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "df-schema.Online-Course", newName: "OnlineCourse");
        }
        
        public override void Down()
        {
            RenameTable(name: "df-schema.OnlineCourse", newName: "Online-Course");
        }
    }
}
