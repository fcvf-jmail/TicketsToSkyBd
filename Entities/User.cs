namespace TicketsToSkyBd.Entities;
public class User
{
    public int Id { get; set; }
    public required string ChatId { get; set; }
    public string? Username { get; set; }
    public required string FirstName { get; set; }
    public string? LastName { get; set; }
    public required DateTime RegistrationDate { get; set; }
    public override string ToString() => $"Id: {Id}\nChatId: {ChatId}\nUsername: {Username}\nFirstName: {FirstName}\nLastName: {LastName}\nRegistrationDate: {RegistrationDate}";
}