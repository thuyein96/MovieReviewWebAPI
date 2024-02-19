using MovieReviewWebAPI.Models;

namespace MovieReviewWebAPI.Interfaces
{
    public interface IReviewerRepository
    {
       ICollection<Reviewer> GetReviewers();
       Reviewer GetReviewer(int reviewerId);
       bool ReviewerExists(int reviewerId);
       ICollection<Review> GetReviewByReviewerId(int reviewerId);
       bool CreateReviewer(Reviewer reviewer);
       bool UpdateReviewer(Reviewer reviewer);
       bool DeleteReviewer(Reviewer reviewer);
       bool Save();
    }
}
