
// MF: Every entity that will be added manually or will be DISCOVERED & added by EF must contain an
// ID property (column)

namespace CodeFirst.DAL
{
    using System.Data.Entity;
    using CodeFirst.Model;
    using EntityLayer.Model;

    public class SchoolContext : DbContext
    {
        public SchoolContext() : base()
        {

        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Standard> Standards { get; set; }
        public DbSet<Cook> Cooks { get; set; }
        public DbSet<Rule> Rules { get; set; }

        // POI: Printer is defined in another library project
        // POI: Printer has a Derived class which will also be DISCOVERED & added as table by EF

        public DbSet<Printer> Printers { get; set; }
    }
}
