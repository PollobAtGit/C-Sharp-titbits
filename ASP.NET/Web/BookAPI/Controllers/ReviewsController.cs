using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using BookAPI.DAL;
using BookAPI.Models;
using BookAPI.ViewModel;

namespace BookAPI.Controllers
{
    public class ReviewsController : ApiController
    {
        readonly BooksContext _context = new BooksContext();

        // POST: api/Reviews
        [ResponseType(typeof(Review))]
        public async Task<IHttpActionResult> PostReview([FromBody] ReviewViewModel vModel)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var book = await _context.Books.FirstOrDefaultAsync(x => x.Id == vModel.BookId);

            if (book == null) return NotFound();

            _context.Reviews.Add(vModel.ToReview());

            await _context.SaveChangesAsync();

            return Ok(vModel);
        }

        // DELETE: api/Reviews/5
        [ResponseType(typeof(Review))]
        public async Task<IHttpActionResult> DeleteReview(int id)
        {
            var review = await _context.Reviews.FirstOrDefaultAsync(x => x.Id == id);

            if (review == null) return NotFound();

            _context.Reviews.Remove(review);

            await _context.SaveChangesAsync();

            return Ok();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _context.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}