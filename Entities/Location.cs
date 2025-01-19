namespace TicketsToSkyBd.Entities;
public class Location
{
    public int Id { get; set; }
    public required string Code { get; set; }
    public required string Country { get; set; }
    public required string City { get; set; }
    public string? Airport { get; set; }

    public override string ToString() => $"Id: {Id}\nCode: {Code}\nCountry: {Country}\nCity: {City}\nAirport: {Airport}";
}
