using MovieReviewWebAPI.Data;
using MovieReviewWebAPI.Interfaces;
using MovieReviewWebAPI.Models;

namespace MovieReviewWebAPI.Repository
{
    public class GenreRepository : IGenreRepository
    {
        private readonly DataContext _context;

        public GenreRepository(DataContext context)
        {
            _context = context;
        }

        public bool GenreExists(int genreId)
        {
            return _context.Genres.Any(g => g.Id == genreId);
        }

        public ICollection<Genre> GetGenres()
        {
            return _context.Genres.ToList();
        }

        public Genre GetGenre(int genreId)
        {
            return _context.Genres.Where(g => g.Id == genreId).FirstOrDefault();
        }

        public ICollection<Movie> GetMovieByGenreId(int genreId)
        {
            return _context.MoviesGenres.Where(mg => mg.GenreId == genreId).Select(g => g.Movie).ToList();
        }

        public bool CreateGenre(Genre genre)
        {
            _context.Add(genre);
            return Save();
        }

        public bool UpdateGenre(Genre genre)
        {
            _context.Update(genre);
            return Save();
        }

        public bool DeleteGenre(Genre genre)
        {
            _context.Remove(genre);
            return Save();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }
    }
}
