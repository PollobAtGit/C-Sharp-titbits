using ObjectModel.Model;
using System.Data.Entity;

namespace ObjectModel.DAL
{
    public class BreakAwayContext : DbContext
    {
        public DbSet<Destination> Destinations { get; set; }

        public DbSet<Lodging> Lodgings { get; set; }
    }
}
