using System.Text;

namespace TicketsToSkyBd.Entities;
public class Notification
{
    public int Id { get; set; }
    public int TicketId { get; set; }
    public int UserId { get; set; }
    public required bool Sent { get; set; }
    public string? FailureReason { get; set; }
    public required DateTime AttemptedAt { get; set; }
    public required FoundTicket FoundTicket { get; set; }
    public required User User { get; set; }

    public override string ToString()
    {
        StringBuilder stringBuilder = new($"Id: {Id}\nSent: {Sent}");
        if(FailureReason is not null) stringBuilder.Append($"\nFailure reason: {FailureReason}");
        stringBuilder.Append($"\nAttempted at: {AttemptedAt}\n\nFound Ticket:\n\n{FoundTicket}\n\nUser: {User}");
        return stringBuilder.ToString();
    }
}
