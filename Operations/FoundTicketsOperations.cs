namespace TicketsToSkyBd.Operations;
using TicketsToSkyBd.Entities;
using System.Globalization;
using Microsoft.EntityFrameworkCore;

public class FoundTicketsOperations
{
    public static FoundTicket AddFoundTicket(AppDbContext appDbContext, int subscriptionId, string departureDateString, string destinationDateString, string departureCode, string destinationCode, decimal price, float baggageWeight, float handBaggageWeight, int transfersCount, int flightDuration)
    {
        string dateFormat = "dd.MM.yyyy HH:mm:ss"; // Формат, соответствующий строке

        DateTime departureDate = DateTime.ParseExact(departureDateString, dateFormat, CultureInfo.InvariantCulture);
        DateTime destinationDate = DateTime.ParseExact(destinationDateString, dateFormat, CultureInfo.InvariantCulture);
        Subscription subscription = SubscriptionOperations.GetSubscription(appDbContext, subscriptionId);

        Location departureLocation = LocationOperations.GetLocation(appDbContext, departureCode);
        Location destinationLocation = LocationOperations.GetLocation(appDbContext, destinationCode);

        FoundTicket foundTicket = new()
        {
            DepartureDate = departureDate.ToUniversalTime(),
            DestinationDate = destinationDate.ToUniversalTime(),
            Price = price,
            BaggageWeight = baggageWeight,
            HandBaggageWeight = handBaggageWeight,
            TransfersCount = transfersCount,
            FlightDuration = flightDuration,
            CreatedAt = DateTime.UtcNow,
            DepartureLocation = departureLocation,
            DestinationLocation = destinationLocation,
            Subscription = subscription
        };

        appDbContext.FoundTickets.Add(foundTicket);
        appDbContext.SaveChanges();

        return foundTicket;
    }

    public static FoundTicket GetFoundTicket(AppDbContext appDbContext, int ticketId)
    {
        FoundTicket foundTicket = appDbContext.FoundTickets.Include(foundTicket => foundTicket.DepartureLocation).Include(foundTicket => foundTicket.DestinationLocation).Include(foundTicket => foundTicket.Subscription).First(foundTicket => foundTicket.Id == ticketId);
        return foundTicket;
    }
}