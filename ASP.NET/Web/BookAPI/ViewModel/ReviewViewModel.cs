using BookAPI.Models;

namespace BookAPI.ViewModel
{
    public class ReviewViewModel
    {
        public ReviewViewModel(Review review)
        {
            if (review == null) return;

            BookId = review.BookId;
            Rating = review.Rating;
            Description = review.Description;
        }

        public int BookId { get; private set; }
        public string Description { get; private set; }
        public int Rating { get; private set; }

        public Review ToReview() => new Review
        {
            BookId = BookId,
            Rating = Rating,
            Description = Description
        };
    }
}