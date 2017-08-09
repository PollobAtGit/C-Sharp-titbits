namespace EF.Repository
{
    using System.Data.Entity;

    public class SchoolContext : DbContext
    {
        public SchoolContext()
        {

        }

        public DbSet<Student> Students { get; set; }
    }
}