namespace EF_102.Context
{
    using EF_102.Model;
    using System.Data.Entity;
    using System.Data.Entity.ModelConfiguration.Conventions;

    class EFContext : DbContext
    {
        public EFContext()
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            base.OnModelCreating(modelBuilder);
        }

        // POI: Why virtual DbSet?
        public virtual DbSet<Category> Categories { get; set; }
    }
}
