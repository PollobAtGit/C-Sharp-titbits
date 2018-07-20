using System.Data.Entity;
using Model.Product;

namespace DAL.Context
{
    public class Context : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
    }
}
