using MovieReviewWebAPI.Models;

namespace MovieReviewWebAPI.Interfaces
{
    public interface IProductionRepository
    {
        ICollection<Production> GetProductions();
        Production GetProduction(int productionId);
        bool ProductionExists(int productionId);
        ICollection<Production> GetProductionOfAMovie(int movieId);
        ICollection<Movie> GetMoviesByProductionId(int productionId);
        bool CreateProduction(Production production);
        bool UpdateProduction(Production production);
        bool DeleteProduction(Production production);
        bool Save();
    }
}
