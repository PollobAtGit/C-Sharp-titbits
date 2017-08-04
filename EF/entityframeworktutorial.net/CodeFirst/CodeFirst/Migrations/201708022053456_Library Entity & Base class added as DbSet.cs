namespace CodeFirst.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class LibraryEntityBaseclassaddedasDbSet : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Cooks",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Responsibility = c.String(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Printers",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Rules",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Importance = c.Int(nullable: false),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Rules");
            DropTable("dbo.Printers");
            DropTable("dbo.Cooks");
        }
    }
}
