namespace ObjectModel.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class Init2152018 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Destinations",
                c => new
                    {
                        DestinationId = c.Int(nullable: false, identity: true),
                        LocationName = c.String(nullable: false),
                        Country = c.String(),
                        Description = c.String(maxLength: 500),
                        Photo = c.Binary(storeType: "image"),
                        TravelWarnings = c.String(),
                        ClimateInfo = c.String(),
                    })
                .PrimaryKey(t => t.DestinationId);
            
            CreateTable(
                "dbo.Lodgings",
                c => new
                    {
                        LodgingId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 200),
                        Owner = c.String(),
                        MilesFromNearestAirport = c.Decimal(nullable: false, precision: 18, scale: 2),
                        IsResort = c.Boolean(nullable: false),
                        PrimaryContactId = c.Int(),
                        SecondaryContactId = c.Int(),
                        DestinationId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.LodgingId)
                .ForeignKey("dbo.Destinations", t => t.DestinationId, cascadeDelete: true)
                .ForeignKey("dbo.People", t => t.PrimaryContactId)
                .ForeignKey("dbo.People", t => t.SecondaryContactId)
                .Index(t => t.PrimaryContactId)
                .Index(t => t.SecondaryContactId)
                .Index(t => t.DestinationId);
            
            CreateTable(
                "dbo.InternetSpecials",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Lodging_LodgingId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Lodgings", t => t.Lodging_LodgingId)
                .Index(t => t.Lodging_LodgingId);
            
            CreateTable(
                "dbo.People",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Lodgings", "SecondaryContactId", "dbo.People");
            DropForeignKey("dbo.Lodgings", "PrimaryContactId", "dbo.People");
            DropForeignKey("dbo.InternetSpecials", "Lodging_LodgingId", "dbo.Lodgings");
            DropForeignKey("dbo.Lodgings", "DestinationId", "dbo.Destinations");
            DropIndex("dbo.InternetSpecials", new[] { "Lodging_LodgingId" });
            DropIndex("dbo.Lodgings", new[] { "DestinationId" });
            DropIndex("dbo.Lodgings", new[] { "SecondaryContactId" });
            DropIndex("dbo.Lodgings", new[] { "PrimaryContactId" });
            DropTable("dbo.People");
            DropTable("dbo.InternetSpecials");
            DropTable("dbo.Lodgings");
            DropTable("dbo.Destinations");
        }
    }
}
