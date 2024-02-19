using MovieReviewWebAPI.Data;
using MovieReviewWebAPI.Dto;
using MovieReviewWebAPI.Interfaces;
using MovieReviewWebAPI.Models;

namespace MovieReviewWebAPI.Repository
{
    public class MovieRepository : IMovieRepository
    {
        private readonly DataContext _context;

        public MovieRepository(DataContext context)
        {
            _context = context;
        }

        public bool CreateMovie(int productionId, int genreId, Movie movie)
        {
            var movieProductionEntity = _context.Productions.Where(a => a.Id == productionId).FirstOrDefault();
            var genre = _context.Genres.Where(a => a.Id == genreId).FirstOrDefault();

            var movieProduction = new MovieProduction()
            {
                Production = movieProductionEntity,
                Movie = movie,
            };

            _context.Add(movieProduction);

            var movieGenre = new MovieGenre()
            {
                Genre = genre,
                Movie = movie,
            };

            _context.Add(movieGenre);

            _context.Add(movie);

            return Save();
        }

        public bool DeleteMovie(Movie movie)
        {
            _context.Remove(movie); 
            return Save();
        }

        // Search movie by id
        public Movie GetMovie(int movieId)
        {
            return _context.Movies.Where(m => m.Id == movieId).FirstOrDefault();
        }

        // Search movie by name
        public Movie GetMovie(string movieName)
        {
            return _context.Movies.Where(m => m.Name == movieName).FirstOrDefault();
        }

        public decimal GetMovieRating(int movieId)
        {
            var review = _context.Reviews.Where(r => r.Movie.Id == movieId);

            if (review.Count() <= 0)
                return 0;

            return ((decimal)review.Sum(r => r.Rating) / review.Count());
        }

        // Search movies with list
        public ICollection<Movie> GetMovies()
        {
            return _context.Movies.OrderBy(m => m.Id).ToList();
        }

        public Movie GetMovieTrimToUpper(MovieDto movieCreate)
        {
            return GetMovies().Where(m => m.Name.Trim().ToUpper() == movieCreate.Name.TrimEnd().ToUpper())
                .FirstOrDefault();
        }

        public bool MovieExists(int movieId)
        {
            return _context.Movies.Any(m => m.Id == movieId);
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool UpdateMovie(int productionId, int genreId, Movie movie)
        {
            _context.Update(movie);
            return Save();
        }
    }
}
