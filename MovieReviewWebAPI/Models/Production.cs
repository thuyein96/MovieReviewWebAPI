using MovieReviewWebAPI.Models;

namespace MovieReviewWebAPI.Models
{
    public class Production
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Country Country { get; set; }
        public ICollection<MovieProduction> MovieProductions { get; set; }
    }
}
