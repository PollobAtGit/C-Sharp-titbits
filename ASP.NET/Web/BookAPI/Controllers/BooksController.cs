using System.Data.Entity;
using System.Threading.Tasks;
using System.Web.Http;
using BookAPI.DAL;

namespace BookAPI.Controllers
{
    public class BooksController : ApiController
    {
        public async Task<IHttpActionResult> Get()
        {
            using (var context = new BooksContext())
            {
                return Ok(await context.Books.Include(x => x.Reviews).ToListAsync());
            }
        }
    }
}
