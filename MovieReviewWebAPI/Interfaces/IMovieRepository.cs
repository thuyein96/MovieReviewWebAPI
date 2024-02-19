using MovieReviewWebAPI.Dto;
using MovieReviewWebAPI.Models;

namespace MovieReviewWebAPI.Interfaces
{
    public interface IMovieRepository
    {
        ICollection<Movie> GetMovies();
        Movie GetMovie(int movieId);
        Movie GetMovie(string movieName);
        Movie GetMovieTrimToUpper(MovieDto movieCreate);
        decimal GetMovieRating(int movieId);
        bool MovieExists(int movieId);
        bool CreateMovie(int productionId, int genreId, Movie movie);
        bool UpdateMovie(int productionId, int genreId, Movie movie);
        bool DeleteMovie(Movie movie);
        bool Save();
    }
}
