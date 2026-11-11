# PhotoNetwork

Уеб социална мрежа за фотографи и визуално съдържание. Дипломен проект.

Фотографите публикуват снимки, подреждат ги в албуми и колекции, следват други автори, реагират и коментират. Модераторите обработват сигнали за неподходящо съдържание, а администраторът управлява потребителите и жанровете.

## Технологии

- C#, ASP.NET Core MVC (.NET 10), Razor
- MS SQL Server, Entity Framework Core (Code First, миграции)
- ASP.NET Core Identity (роли: Photographer, Moderator, Administrator)
- HTML5, CSS3, JavaScript
- xUnit за тестове

## Структура

```
src/
  PhotoNetwork.Web        контролери, изгледи, настройки на приложението
  PhotoNetwork.Services   бизнес логика
  PhotoNetwork.Data       entities, DbContext, конфигурации, миграции, seed
  PhotoNetwork.Models     ViewModels
tests/
  PhotoNetwork.Tests      unit тестове
```

Зависимости: Web -> Services -> Data. Models се използва от Web и Services.

## Стартиране

Нужни са .NET SDK 10 и SQL Server (подходящ е LocalDB, който идва с Visual Studio).

1. Задайте настройките в User Secrets (те не се пазят в репото):

   ```
   cd src/PhotoNetwork.Web
   dotnet user-secrets set "ConnectionStrings:DefaultConnection" "Server=(localdb)\MSSQLLocalDB;Database=PhotoNetworkDb;Trusted_Connection=True;TrustServerCertificate=True"
   dotnet user-secrets set "Seed:DemoPassword" "<парола за демо потребителите>"
   ```

2. Стартирайте приложението:

   ```
   dotnet run --project src/PhotoNetwork.Web
   ```

При старт се прилагат миграциите и се създават ролите, жанровете и демо потребителите.

## Демо потребители

Паролата на всички е стойността на `Seed:DemoPassword`.

| Имейл | Роля |
|---|---|
| admin@photonetwork.test | Administrator |
| moderator@photonetwork.test | Moderator |
| anna@photonetwork.test | Photographer |
| boris@photonetwork.test | Photographer |

## Автор

Виторио Чорапинов, 12Г
