
using app_0.Model;
using Microsoft.EntityFrameworkCore;

namespace app_0.Context
{
    internal class BloggingContext : DbContext
    {
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Post> Posts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
            .UseSqlite("Data Source=blogging.db");
        }
    }
}
