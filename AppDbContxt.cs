namespace TicketsToSkyBd;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using TicketsToSkyBd.Entities;

public class AppDbContext : DbContext
{
    private readonly IConfiguration _configuration;
    public DbSet<User> Users { get; set; }
    public DbSet<Location> Locations { get; set; }
    public DbSet<Subscription> Subscriptions { get; set; }
    public DbSet<FoundTicket> FoundTickets { get; set; }
    public DbSet<Notification> Notifications { get; set; }
    
    public AppDbContext()
    {
        _configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            .Build();
    }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var connectionString = _configuration.GetConnectionString("DefaultConnection");
        optionsBuilder.UseNpgsql(connectionString);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<User>()
            .HasIndex(user => user.ChatId)
            .IsUnique();

        modelBuilder.Entity<Location>()
            .HasIndex(location => location.Id)
            .IsUnique();

        modelBuilder.Entity<Subscription>()
            .HasOne(subscription => subscription.User)
            .WithMany()
            .HasForeignKey(subscription => subscription.UserId);

        modelBuilder.Entity<Subscription>()
            .HasOne(subscription => subscription.DepartureLocation)
            .WithMany()
            .HasForeignKey(subscription => subscription.DepartureCode)
            .HasPrincipalKey(location => location.Code);
        
        modelBuilder.Entity<Subscription>()
            .HasOne(subscription => subscription.DestinationLocation)
            .WithMany()
            .HasForeignKey(subscription => subscription.DestinationCode)
            .HasPrincipalKey(location => location.Code);

        modelBuilder.Entity<FoundTicket>()
            .HasOne(foundTicket => foundTicket.Subscription)
            .WithMany()
            .HasForeignKey(foundTicket => foundTicket.SubscriptionId);

        modelBuilder.Entity<FoundTicket>()
            .HasOne(foundTicket => foundTicket.DepartureLocation)
            .WithMany()
            .HasForeignKey(foundTicket => foundTicket.DepartureCode)
            .HasPrincipalKey(location => location.Code);

        modelBuilder.Entity<FoundTicket>()
            .HasOne(foundTicket => foundTicket.DestinationLocation)
            .WithMany()
            .HasForeignKey(foundTicket => foundTicket.DestinationCode)
            .HasPrincipalKey(location => location.Code);

        modelBuilder.Entity<Notification>()
            .HasOne(notification => notification.FoundTicket)
            .WithMany()
            .HasForeignKey(notification => notification.TicketId);

        modelBuilder.Entity<Notification>()
            .HasOne(notification => notification.User)
            .WithMany()
            .HasForeignKey(notification => notification.UserId);

    }
}
