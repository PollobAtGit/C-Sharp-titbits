namespace ObjectModel.Migrations
{
    using ObjectModel.Model;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<ObjectModel.DAL.BreakAwayContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(DAL.BreakAwayContext context)
        {
            var destOne = new Destination
            {
                ClimateInfo = "x",
                Country = "BD",
                Description = "yDescription",
                Name = "zN",
                TravelWarnings = "wWarning",
                Lodgings = new List<Lodging>
                {
                    new Lodging
                    {
                        Name = "xLodging-123",
                        IsResort = true,
                        MilesFromNearestAirport = 10.23m,
                        Owner = "Owner",
                        InternetSpecials = new List<InternetSpecial> { new InternetSpecial() },
                        PrimaryContact = new Person(),
                        SecondaryContact = new Person()
                    },
                    new Lodging
                    {
                        Name = "yLodging-123",
                        IsResort = true,
                        MilesFromNearestAirport = 100.23m,
                        Owner = "xOwner",
                        InternetSpecials = new List<InternetSpecial> { new InternetSpecial() },
                        PrimaryContact = new Person(),
                        SecondaryContact = new Person()
                    }
                }
            };

            var destTwo = new Destination { Name = "yR", Country = "AUS" };

            context.Destinations.AddOrUpdate(destOne);
            context.Destinations.AddOrUpdate(destTwo);
        }
    }
}
