using MovieReviewWebAPI.Data;
using MovieReviewWebAPI.Interfaces;
using MovieReviewWebAPI.Models;

namespace MovieReviewWebAPI.Repository
{
    public class ProductionRepository : IProductionRepository
    {
        private readonly DataContext _context;

        public ProductionRepository(DataContext context)
        {
            _context = context;
        }

        public ICollection<Production> GetProductionOfAMovie(int movieId)
        {
            return _context.MoviesProductions.Where(mp => mp.Movie.Id == movieId).Select(p => p.Production).ToList();
        }

        public ICollection<Movie> GetMoviesByProductionId(int productionId)
        {
            return _context.MoviesProductions.Where(mp => mp.ProductionId == productionId).Select(m => m.Movie).ToList();
        }

        public Production GetProduction(int productionId)
        {
            return _context.Productions.Where(p => p.Id == productionId).FirstOrDefault();
        }

        public ICollection<Production> GetProductions()
        {
            return _context.Productions.ToList();
        }

        public bool ProductionExists(int productionId)
        {
            return _context.Productions.Any(p => p.Id == productionId);
        }

        public bool CreateProduction(Production production)
        {
            _context.Add(production);
            return Save();
        }

        public bool UpdateProduction(Production production)
        {
            _context.Update(production);
            return Save();
        }

        public bool DeleteProduction(Production production)
        {
            _context.Remove(production);
            return Save();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }
    }
}
