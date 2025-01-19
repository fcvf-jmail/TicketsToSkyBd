using System.Globalization;
using System.Reflection.PortableExecutable;
using Microsoft.EntityFrameworkCore;
using TicketsToSkyBd.Entities;

namespace TicketsToSkyBd.Operations;

public class SubscriptionOperations
{
    public static Subscription CreateSubscription(AppDbContext appDbContext, string chatId, string fromDateString, string toDateString, string departureCode, string destinationCode, decimal? maxPrice, float? minBaggageWeight, float? minHandBaggageWeight, int? maxTransfersCount, int? maxFlightDuration)
    {
        Location departureLocation = LocationOperations.GetLocation(appDbContext, departureCode);
        Location destinationLocation = LocationOperations.GetLocation(appDbContext, destinationCode);
        
        User? user = UserOperations.GetUser(appDbContext, chatId);

        string dateFormat = "dd.MM.yyyy"; // Формат, соответствующий строке

        DateTime fromDate = DateTime.ParseExact(fromDateString, dateFormat, CultureInfo.InvariantCulture).ToUniversalTime();
        DateTime toDate = DateTime.ParseExact(toDateString, dateFormat, CultureInfo.InvariantCulture).ToUniversalTime();

        Subscription subscription = new()
        {
            DepartureCode = departureCode,
            DestinationCode = destinationCode,
            User = user,
            DepartureLocation = departureLocation,
            DestinationLocation = destinationLocation,
            FromDate = fromDate,
            ToDate = toDate,
            MaxPrice = maxPrice,
            MinBaggageWeight = minBaggageWeight,
            MinHandBaggageWeight = minHandBaggageWeight,
            MaxTransfersCount = maxTransfersCount,
            MaxFlightDuration = maxFlightDuration,
            SearchCount = 0,
            CreatedAt = DateTime.UtcNow
        };

        appDbContext.Subscriptions.Add(subscription);
        appDbContext.SaveChanges();

        return subscription;
    }

    public static Subscription GetSubscription(AppDbContext appDbContext, int subscriptionId)
    {
        Subscription subscription = appDbContext.Subscriptions.Include(subscription => subscription.DepartureLocation).Include(subscription => subscription.DestinationLocation).First(subscription => subscription.Id == subscriptionId);
        return subscription;
    }

    public static List<Subscription>? GetUsersSubscriptions(AppDbContext appDbContext, string chatId)
    {
        List<Subscription>? subscriptions = appDbContext.Subscriptions.Where(subscription => subscription.User.ChatId == chatId).Include(subscription => subscription.DepartureLocation).Include(subscription => subscription.DestinationLocation)?.ToList();
        return subscriptions;
    }

    public static void DeleteSubscription(AppDbContext appDbContext, int subscriptionId)
    {
        appDbContext.Subscriptions.Remove(appDbContext.Subscriptions.First(subscription => subscription.Id == subscriptionId));
        appDbContext.SaveChanges();
    }
}