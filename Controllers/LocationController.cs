using Microsoft.AspNetCore.Mvc;
using TicketsToSkyBd.Operations;
using TicketsToSkyBd.Entities;

namespace TicketsToSkyBd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocationController : ControllerBase
    {
        private readonly AppDbContext _context;

        public LocationController(AppDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public ActionResult<Location> CreateLocation([FromBody] LocationRequest request)
        {
            var location = LocationOperations.CreateLocation(
                _context, 
                request.Code, 
                request.Country, 
                request.City, 
                request.Airport
            );
            return CreatedAtAction(nameof(GetLocation), new { code = location.Code }, location);
        }

        [HttpGet("{code}")]
        public ActionResult<Location> GetLocation(string code)
        {
            var location = LocationOperations.GetLocation(_context, code);
            if (location == null)
            {
                return NotFound();
            }
            return Ok(location);
        }
    }

    public class LocationRequest
    {
        public required string Code { get; set; }
        public required string Country { get; set; }
        public required string City { get; set; }
        public string? Airport { get; set; }
    }
}
