using Microsoft.EntityFrameworkCore;

namespace MvcMovie.Models.Context
{
    public class MvcMovieContext : DbContext
    {
        public DbSet<Movie> Movies { get; set; }

        public MvcMovieContext(DbContextOptions<MvcMovieContext> options) : base(options)
        {

        }
    }
}