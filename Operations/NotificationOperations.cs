namespace TicketsToSkyBd.Operations;

using Microsoft.EntityFrameworkCore;
using TicketsToSkyBd.Entities;

public class NotificationOperations
{
    public static Notification AddNotification(AppDbContext appDbContext, int ticketId, int userId, bool sent, string? failureReason)
    {
        User user = UserOperations.GetUser(appDbContext, userId);
        FoundTicket foundTicket = FoundTicketsOperations.GetFoundTicket(appDbContext, ticketId);
        Notification notification = new()
        {
            Sent = sent,
            AttemptedAt = DateTime.UtcNow,
            FoundTicket = foundTicket,
            User = user
        };

        appDbContext.Notifications.Add(notification);
        appDbContext.SaveChanges();

        return notification;
    }

    public static Notification GetNotification(AppDbContext appDbContext, int notificationId)
    {
        Notification notification = appDbContext.Notifications.Include(notification => notification.FoundTicket).Include(notification => notification.User).Include(notification => notification.FoundTicket.DepartureLocation).Include(notification => notification.FoundTicket.DestinationLocation).First(notification => notification.Id == notificationId);
        return notification;
    }
}