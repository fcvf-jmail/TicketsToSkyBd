using TicketsToSkyBd;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;

using AppDbContext appDbContext = new();

var builder = WebApplication.CreateBuilder(args);

// Добавляем поддержку контроллеров
builder.Services.AddControllers();
builder.Services.AddDbContext<AppDbContext>();

var app = builder.Build();

// Применяем миграции при старте приложения (если они не применены)
using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    dbContext.Database.Migrate();
}

// Конфигурируем маршруты
app.MapControllers();

// Запускаем приложение
app.Run();
