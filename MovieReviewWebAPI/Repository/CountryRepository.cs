using MovieReviewWebAPI.Data;
using MovieReviewWebAPI.Interfaces;
using MovieReviewWebAPI.Models;

namespace MovieReviewWebAPI.Repository
{
    public class CountryRepository : ICountryRepository
    {
        private readonly DataContext _context;

        public CountryRepository(DataContext context)
        {
            _context = context;
        }

        public bool CountryExists(int countryId)
        {
            return _context.Countries.Any(c => c.Id == countryId);
        }

        public bool CreateCountry(Country country)
        {
            _context.Add(country);
            return Save();
        }

        public bool DeleteCountry(Country country)
        {
            _context.Remove(country);
            return Save();
        }

        public ICollection<Country> GetCountries()
        {
            return _context.Countries.ToList();
        }

        public Country GetCountry(int countryId)
        {
            return _context.Countries.Where(g => g.Id == countryId).FirstOrDefault();
        }

        public Country GetCountryOfAProduction(int productionId)
        {
            return _context.Productions.Where(p => p.Id == productionId).Select(c => c.Country).FirstOrDefault();
        }

        public ICollection<Production> GetProductionFromACountry(int countryId)
        {
            return _context.Productions.Where(p => p.Country.Id == countryId).ToList();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool UpdateCountry(Country country)
        {
            _context.Update(country);
            return Save();
        }
    }
}
