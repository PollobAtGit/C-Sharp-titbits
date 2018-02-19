namespace CodeFirst.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class AddpropertiesintoderivedCookRuleclasses : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Cooks", "Experience", c => c.String());
            AddColumn("dbo.Cooks", "PhoneNumber", c => c.String());
            AddColumn("dbo.Rules", "ApplicableToClass", c => c.String());
            AddColumn("dbo.Rules", "ApplicableToTeacher", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Rules", "ApplicableToTeacher");
            DropColumn("dbo.Rules", "ApplicableToClass");
            DropColumn("dbo.Cooks", "PhoneNumber");
            DropColumn("dbo.Cooks", "Experience");
        }
    }
}
