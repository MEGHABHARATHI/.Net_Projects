using Microsoft.AspNetCore.Mvc;
using TourWebAPI.DTO;
using TourWebAPI.Models;
using TourWebAPI.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TourWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TouristController : ControllerBase
    {
        ITouristService touristService;

        public TouristController (ITouristService _touristServices)
        {
            touristService = _touristServices;
        }
        
        
        
        
        [HttpGet("GetAllTouristPlaces")]
        public ActionResult<IEnumerable<TouristResponseDTO>> GetAllPlaces()
        {
            var allPlaces = touristService.GetAllPlaces();

            return Ok(allPlaces);
        }

        // GET api/<TouristController>/5
        [HttpGet("GetHillStations/{altitude:int}")]
        public ActionResult<IEnumerable<TouristResponseDTO>> GetHillStation(int altitude)
        {
            var highPlaces = touristService.GetPlacesAboveAltitude(altitude);
            return Ok(highPlaces);
        }

        // POST api/<TouristController>
        [HttpPost("CreatTouristPlace")]
        public async Task<ActionResult<string>> CreateTouristPlace([FromBody] TouristResponseDTO tourDTO)
        {
            Place newPlace = new Place
            {
                Name = tourDTO.Name,
                Desc = tourDTO.Description,
                Altitude = tourDTO.Altitude

            };
            var ret = await touristService.CreatePlaceAsync(newPlace);
            if(ret)
            {
                return Created();

            }
            else
            {
                return BadRequest("not connected");
            }
        }


    }
}
