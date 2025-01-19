using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Microsoft.Extensions.Logging.Abstractions;

namespace TicketsToSkyBd.Entities;
public class FoundTicket
{
    public int Id { get; set; }
    public int SubscriptionId { get; set; }
    public required DateTime DepartureDate { get; set; }
    public required DateTime DestinationDate { get; set; }
    public decimal? Price { get; set; }
    public float? BaggageWeight { get; set; }
    public float? HandBaggageWeight { get; set; }
    public int? TransfersCount { get; set; }
    public int? FlightDuration { get; set; }
    public required DateTime CreatedAt { get; set; }
    public string? DepartureCode { get; set; }
    public string? DestinationCode { get; set; }
    
    public required Subscription Subscription { get; set; }
    public required Location DepartureLocation { get; set; }
    public required Location DestinationLocation { get; set; }

    public override string ToString()
    {
        StringBuilder stringBuilder = new($"Id: {Id}\nDeparture date: {DepartureDate}\nDestination date: {DestinationDate}");
        
        if(Price is not null) stringBuilder.Append($"\nMax Price: {Price}");
        if(BaggageWeight is not null) stringBuilder.Append($"\nBaggage weight: {BaggageWeight}");
        if(HandBaggageWeight is not null) stringBuilder.Append($"\nHand baggage weight: {HandBaggageWeight}");
        if(TransfersCount is not null) stringBuilder.Append($"\nTransfers count: {TransfersCount}");
        if(FlightDuration is not null) stringBuilder.Append($"\nFlight duration: {FlightDuration}");

        stringBuilder.Append($"\nCreated at: {CreatedAt}\n\nDeparture location: {DepartureLocation}\n\nDestination location: {DestinationLocation}\n\nSubscription: {Subscription}");

        return stringBuilder.ToString();
    }
}