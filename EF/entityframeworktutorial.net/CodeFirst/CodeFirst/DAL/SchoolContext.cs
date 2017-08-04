
// MF: Every entity that will be added manually or will be DISCOVERED & added by EF must contain an
// ID property (column)

namespace CodeFirst.DAL
{
    using System.Data.Entity;
    using CodeFirst.Model;
    using EntityLayer.Model;
    using System.Data.Entity.ModelConfiguration.Conventions;

    public class SchoolContext : DbContext
    {
        public SchoolContext() : base()
        {
        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Standard> Standards { get; set; }
        public DbSet<Cook> Cooks { get; set; }
        public DbSet<Rule> Rules { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Employee> Employees { get; set; }

        // POI: Printer is defined in another library project
        // POI: Printer has a Derived class which will also be DISCOVERED & added as table by EF

        public DbSet<Printer> Printers { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // POI: Default schema name
            modelBuilder.HasDefaultSchema("df-schema");

            // POI: Not mentioning abstract class is all we need to exclude that from table creation
            modelBuilder.Entity<OnlineCourse>().Map(m =>
            {
                // POI: MapInheritedProperties will takes all the inherited properties from the base class to
                // derived class. Other properties that are part of the mentioned Type will be included too
                m.MapInheritedProperties();

                // POI: Db table name
                m.ToTable("Online-Course");
            });

            modelBuilder.Entity<OfflineCourse>().Map(m =>
            {
                // POI: This statement will make the derived class to inherit all the properties from 
                // base class
                m.MapInheritedProperties();

                // POI: ToTable(...) will create a table with the specified name
                m.ToTable("OfflineCourse");
            });

            // POI: Following throws exception '...was configured but is not used in any mappings...' because 
            // class is abstract. We can't make a table for an abstract class

            //modelBuilder.Entity<Course>().ToTable("base_course");

            // POI: Splitting Entity into two tables
            modelBuilder.Entity<Employee>().Map(map =>
            {
                map.Properties(e => new { e.Id, e.EmployeeName });
                map.ToTable("employee");
            }).Map(map =>
            {
                map.Properties(e => new { e.Email, e.PhoneNumber });
                map.ToTable("employee-details");
            }).Ignore(e => e.NickName);

            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            // POI: It's a better approach to invoke the base method unless intentional
            base.OnModelCreating(modelBuilder);
        }
    }
}
