using System.Data.Entity;

namespace Ch_11.Controllers
{
    public class ItemDbContext : DbContext
    {
        public DbSet<Item> Items { get; set; }

        public ItemDbContext() : base("DefaultConnection")
        {
        }

    }
}