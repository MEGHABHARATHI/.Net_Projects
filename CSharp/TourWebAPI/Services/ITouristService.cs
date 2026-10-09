using TourWebAPI.Models;

namespace TourWebAPI.Services

{

    public interface ITouristService    {

        Task<IEnumerable<Place>> GetAllPlaces();


        Task<IEnumerable<Place>> GetPlacesAboveAltitude(int altitude);


        Task<bool> CreatePlaceAsync(Place newPlace);

    }

}