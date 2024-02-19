using Microsoft.EntityFrameworkCore.Infrastructure;

namespace MovieReviewWebAPI.Models
{
    public class Country
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Production> Productions { get; set; }
    }
}
