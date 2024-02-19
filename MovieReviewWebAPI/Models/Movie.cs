namespace MovieReviewWebAPI.Models
{
    public class Movie
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime ReleaseDate { get; set; }
        public ICollection<Review> Reviews { get; set; }
        public ICollection<MovieProduction> MovieProductions { get; set; }
        public ICollection<MovieGenre> MovieGenres { get; set; }
    }
}
