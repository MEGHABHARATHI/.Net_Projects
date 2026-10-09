using Microsoft.EntityFrameworkCore;
using TourWebAPI.Data;
using TourWebAPI.Models;

namespace TourWebAPI.Services

{

    public class TouristService : ITouristService
    {

        private readonly TouristDbContext touristDbContext;


        public TouristService(TouristDbContext _touristDbContext)

        {

            touristDbContext = _touristDbContext;

        }


        public async Task<IEnumerable<Place>> GetAllPlaces()

        {

            var allPlaces = await touristDbContext.Places.ToListAsync();

            return allPlaces;

        }


        public async Task<IEnumerable<Place>> GetPlacesAboveAltitude(int altitude)

        {

            var highPlaces = await touristDbContext.Places.Where(x => x.Altitude > altitude).ToListAsync();

            return highPlaces;

        }


        public async Task<bool> CreatePlaceAsync(Place newPlace)

        {

            await touristDbContext.Places.AddAsync(newPlace);

            await touristDbContext.SaveChangesAsync();

            return true;

        }

    }

}