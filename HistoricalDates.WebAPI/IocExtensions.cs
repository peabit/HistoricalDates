using HistoricalDates.Application;
using HistoricalDates.Domain.HistoricalDate;
using HistoricalDates.Infrastructure;
using MongoDB.Driver;

namespace HistoricalDates.WebAPI;

public static class IocExtensions
{
    public static void AddMongoDb(this IServiceCollection services)
    {
        var dates = new MongoClient()
            .GetDatabase("dates")
            .GetCollection<HistoricalDate>("dates");

        services.AddSingleton<IMongoCollection<HistoricalDate>>(dates);
    }

    public static void AddMapper(this IServiceCollection services)
        => services.AddSingleton<Mapper>();
    
    public static void AddRepository(this IServiceCollection services)
        => services.AddSingleton<IHistoricalDateRepository, MongoDbHistoricalDateRepository>();
    
    public static void AddDatesService(this IServiceCollection services)
        => services.AddSingleton<DatesService>();
}