namespace CodeFirst.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class D : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "df-schema.OfflineCourse", newName: "Offline-Course");
            RenameTable(name: "df-schema.OnlineCourse", newName: "Online-Course");
        }
        
        public override void Down()
        {
            RenameTable(name: "df-schema.Online-Course", newName: "OnlineCourse");
            RenameTable(name: "df-schema.Offline-Course", newName: "OfflineCourse");
        }
    }
}
