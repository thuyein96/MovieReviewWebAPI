using Microsoft.AspNetCore.Components.Web;
using MovieReviewWebAPI.Models;

namespace MovieReviewWebAPI.Interfaces
{
    public interface IReviewRepository
    {
        ICollection<Review> GetReviews();
        Review GetReview(int reviewId);
        bool ReviewExists(int reviewId);
        ICollection<Review> GetReviewOfAMovie(int movidId);
        bool CreateReview(Review review);
        bool UpdateReview(Review review);
        bool DeleteReview(Review review);
        bool DeleteReviews(List<Review> reviews);
        bool Save();

    }
}
