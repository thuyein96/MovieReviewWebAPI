using MovieReviewWebAPI.Models;

namespace MovieReviewWebAPI.Interfaces
{
    public interface IGenreRepository
    {
        ICollection<Genre> GetGenres();

        Genre GetGenre(int genreId);
        bool GenreExists(int genreId);
        ICollection<Movie> GetMovieByGenreId(int genreID);

        bool CreateGenre(Genre genre);
        bool UpdateGenre(Genre genre);
        bool DeleteGenre(Genre genre);
        bool Save();

    }
}
