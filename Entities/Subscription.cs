using System.Text;

namespace TicketsToSkyBd.Entities;
public class Subscription
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public required DateTime FromDate { get; set; }
    public required DateTime ToDate { get; set; }
    public decimal? MaxPrice { get; set; }
    public float? MinBaggageWeight { get; set; }
    public float? MinHandBaggageWeight { get; set; }
    public int? MaxTransfersCount { get; set; }
    public int? MaxFlightDuration { get; set; }
    public required int SearchCount { get; set; }
    public required DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }

    public required string DepartureCode { get; set; }
    public required string DestinationCode { get; set; }

    public required Location DepartureLocation { get; set; }
    public required Location DestinationLocation { get; set; }
    public required User User { get; set; }

    public override string ToString()
    {
        StringBuilder stringBuilder = new($"Id: {Id}\nFrom date: {FromDate}\nTo date: {ToDate}");
        
        if(MaxPrice is not null) stringBuilder.Append($"\nMax Price: {MaxPrice}");
        if(MinBaggageWeight is not null) stringBuilder.Append($"\nMin baggage weight: {MinBaggageWeight}");
        if(MinHandBaggageWeight is not null) stringBuilder.Append($"\nMin hand baggage weight: {MinHandBaggageWeight}");
        if(MaxTransfersCount is not null) stringBuilder.Append($"\nMax transfers count: {MaxTransfersCount}");
        if(MaxFlightDuration is not null) stringBuilder.Append($"\nMax flight duration: {MaxFlightDuration}");

        stringBuilder.Append($"\nSearch count: {SearchCount}\nCreated at: {CreatedAt}\nUpdated at: {UpdatedAt}\n\nDeparture location: {DepartureLocation}\n\nDestination location: {DestinationLocation}\n\nUser: {User}");

        return stringBuilder.ToString();
    }
}




