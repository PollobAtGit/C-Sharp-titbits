using System.Data.Entity;
using BookAPI.Models;

namespace BookAPI.DAL
{
    public class BooksContext : DbContext
    {
        public DbSet<Book> Books { get; set; }
        public DbSet<Review> Reviews { get; set; }
    }
}