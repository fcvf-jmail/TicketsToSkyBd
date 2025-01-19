namespace TicketsToSkyBd.Operations;
using TicketsToSkyBd.Entities;

public class LocationOperations
{
    public static Location CreateLocation(AppDbContext appDbContext, string code, string country, string city, string airport)
    {
        Location? checkLocation = GetLocation(appDbContext, code);
        if(checkLocation is not null) return checkLocation;

        Location location = new()
        {
            Code = code,
            Country = country,
            City = city,
            Airport = airport
        };
        
        appDbContext.Locations.Add(location);
        appDbContext.SaveChanges();
        return location;
    }

    public static Location? GetLocation(AppDbContext appDbContext, string code)
    {
        Location? location = appDbContext.Locations.FirstOrDefault(location => location.Code == code);
        return location;
    }
}