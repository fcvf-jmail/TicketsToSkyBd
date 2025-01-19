using Microsoft.AspNetCore.Mvc;
using TicketsToSkyBd.Operations;
using TicketsToSkyBd.Entities;

namespace TicketsToSkyBd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FoundTicketsController(AppDbContext context) : ControllerBase
    {
        private readonly AppDbContext _context = context;

        [HttpPost]
        public ActionResult<FoundTicket> AddFoundTicket([FromBody] FoundTicketRequest request)
        {
            var foundTicket = FoundTicketsOperations.AddFoundTicket(
                _context, 
                request.SubscriptionId, 
                request.DepartureDate, 
                request.DestinationDate, 
                request.DepartureCode, 
                request.DestinationCode, 
                request.Price, 
                request.BaggageWeight, 
                request.HandBaggageWeight, 
                request.TransfersCount, 
                request.FlightDuration
            );
            return foundTicket;
        }

        [HttpGet("{ticketId}")]
        public ActionResult<FoundTicket> GetFoundTicket(int ticketId)
        {
            var foundTicket = FoundTicketsOperations.GetFoundTicket(_context, ticketId);
            if (foundTicket == null)
            {
                return NotFound();
            }
            return Ok(foundTicket);
        }
    }

    public class FoundTicketRequest
    {
        public int SubscriptionId { get; set; }
        public required string DepartureDate { get; set; }
        public required string DestinationDate { get; set; }
        public required string DepartureCode { get; set; }
        public required string DestinationCode { get; set; }
        public decimal Price { get; set; }
        public float BaggageWeight { get; set; }
        public float HandBaggageWeight { get; set; }
        public int TransfersCount { get; set; }
        public int FlightDuration { get; set; }
    }
}
