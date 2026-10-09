using Microsoft.EntityFrameworkCore;
using TourWebAPI.Models;
namespace TourWebAPI.Data
{
    public class TouristDbContext : DbContext
    {
        public DbSet<Place> Places { get; set; }

        public TouristDbContext(DbContextOptions<TouristDbContext> options) : base(options)
        {

        }
    }
}
