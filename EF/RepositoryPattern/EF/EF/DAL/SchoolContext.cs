namespace EF.DAL
{
    using System.Data.Entity;

    public class SchoolContext : DbContext
    {
        public SchoolContext()
        {

        }

        // POI: Can we deal with it using generics?
        public DbSet<Student> Students { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("stv");

            base.OnModelCreating(modelBuilder);
        }
    }
}