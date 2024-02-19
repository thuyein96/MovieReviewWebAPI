using MovieReviewWebAPI.Models;

namespace MovieReviewWebAPI.Models
{
    public class MovieProduction
    {
        public int MovieId { get; set; }
        public int ProductionId { get; set; }
        public Movie Movie { get; set; }
        public Production Production { get; set; }
    }
}
