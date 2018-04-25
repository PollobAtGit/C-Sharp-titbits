
using app_0.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;

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

            // POI: This is awesome. Throws exception if some part of the EF query is evaluated on client side
            // which might not be intentional
            // .ConfigureWarnings(x => x.Throw(RelationalEventId.QueryClientEvaluationWarning));
        }
    }
}
