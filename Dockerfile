# Используем официальный образ .NET SDK для сборки приложения
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build

# Устанавливаем рабочую директорию
WORKDIR /app

# Копируем csproj файл и восстанавливаем зависимости
COPY "TicketsToSkyBd.csproj" .
RUN dotnet restore "TicketsToSkyBd.csproj"

# Копируем все остальные файлы и строим проект
COPY . .
RUN dotnet publish "TicketsToSkyBd.csproj" -c Release -o /app/publish

# Стартовый образ для контейнера (для запуска приложения)
FROM mcr.microsoft.com/dotnet/aspnet:8.0

# Устанавливаем рабочую директорию
WORKDIR /app

# Копируем собранное приложение
COPY --from=build /app/publish .

# Указываем порт, который будет слушать приложение
EXPOSE 5000

COPY appsettings.json /app/

# Команда для запуска приложения
ENTRYPOINT ["dotnet", "TicketsToSkyBd.dll"]

CMD ["sh", "-c", "dotnet ef database update && dotnet TicketsToSkyBd.dll"]