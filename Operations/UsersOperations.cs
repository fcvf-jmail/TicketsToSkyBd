
namespace TicketsToSkyBd.Operations;

using Microsoft.EntityFrameworkCore;
using TicketsToSkyBd.Entities;

public class UserOperations
{
    public static void AddUser(AppDbContext dbContext, string chatId, string? username, string firstName, string? lastName)
    {
        var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
        optionsBuilder.UseNpgsql("Host=localhost;Database=TicketsToSky;Username=jmail;Password=Jmail09022006@");
        if(GetUser(dbContext, chatId) is not null) return;
        
        User user = new()
        {
            ChatId = chatId,
            Username = username,
            FirstName = firstName,
            LastName = lastName,
            RegistrationDate = DateTime.UtcNow
        };
        
        dbContext.Users.Add(user);
        dbContext.SaveChanges();
    }

    public static User? GetUser(AppDbContext appDbContext, string chatId)
    {
        User? user = appDbContext.Users.FirstOrDefault(user => user.ChatId == chatId);
        return user;
    }

    public static User GetUser(AppDbContext appDbContext, int userId)
    {
        User user = appDbContext.Users.First(user => user.Id == userId);
        return user;
    }

    public static void UpdateUser(AppDbContext dbContext, int userId)
    {
        var user = dbContext.Users.FirstOrDefault(u => u.Id == userId);
        if (user != null)
        {
            user.FirstName = "Updated Name";
            dbContext.SaveChanges();  // Сохраняем изменения
        }
    }

    public static void DeleteUser(AppDbContext dbContext, int userId)
    {
        var user = dbContext.Users.FirstOrDefault(u => u.Id == userId);
        if (user != null)
        {
            dbContext.Users.Remove(user);
            dbContext.SaveChanges();  // Удаляем пользователя из базы данных
        }
    }

    public static void ViewUsers(AppDbContext dbContext)
    {
        var users = dbContext.Users.ToList();
        foreach (var user in users)
        {
            Console.WriteLine($"ID: {user.Id}, Name: {user.FirstName} {user.LastName}");
        }
    }
}
