using Microsoft.AspNetCore.Mvc;
using TicketsToSkyBd.Operations;
using TicketsToSkyBd.Entities;

namespace TicketsToSkyBd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubscriptionController : ControllerBase
    {
        private readonly AppDbContext _context;

        public SubscriptionController(AppDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public ActionResult<Subscription> CreateSubscription([FromBody] SubscriptionRequest request)
        {
            var subscription = SubscriptionOperations.CreateSubscription(
                _context, 
                request.ChatId, 
                request.FromDate, 
                request.ToDate, 
                request.DepartureCode, 
                request.DestinationCode, 
                request.MaxPrice, 
                request.MinBaggageWeight, 
                request.MinHandBaggageWeight, 
                request.MaxTransfersCount, 
                request.MaxFlightDuration
            );
            return CreatedAtAction(nameof(GetSubscription), new { subscriptionId = subscription.Id }, subscription);
        }

        [HttpGet("{subscriptionId}")]
        public ActionResult<Subscription> GetSubscription(int subscriptionId)
        {
            var subscription = SubscriptionOperations.GetSubscription(_context, subscriptionId);
            if (subscription == null)
            {
                return NotFound();
            }
            return Ok(subscription);
        }

        [HttpGet("User/{chatId}")]
        public ActionResult<List<Subscription>> GetUsersSubscriptions(string chatId)
        {
            var subscriptions = SubscriptionOperations.GetUsersSubscriptions(_context, chatId);
            return Ok(subscriptions);
        }

        [HttpDelete("{subscriptionId}")]
        public ActionResult DeleteUsersSubscription(int subscriptionId)
        {
            SubscriptionOperations.DeleteSubscription(_context, subscriptionId);
            return Ok();
        }
    }

    public class SubscriptionRequest
    {
        public required string ChatId { get; set; }
        public required string FromDate { get; set; }
        public required string ToDate { get; set; }
        public required string DepartureCode { get; set; }
        public required string DestinationCode { get; set; }
        public decimal? MaxPrice { get; set; }
        public float? MinBaggageWeight { get; set; }
        public float? MinHandBaggageWeight { get; set; }
        public int? MaxTransfersCount { get; set; }
        public int? MaxFlightDuration { get; set; }
    }
}
