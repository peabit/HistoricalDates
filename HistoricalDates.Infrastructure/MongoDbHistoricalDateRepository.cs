using HistoricalDates.Domain.DateModel.Base;
using HistoricalDates.Domain.HistoricalDate;
using MongoDB.Driver;

namespace HistoricalDates.Infrastructure;

public class MongoDbHistoricalDateRepository : IHistoricalDateRepository
{
    private readonly IMongoCollection<HistoricalDate> _dates;

    public MongoDbHistoricalDateRepository(IMongoCollection<HistoricalDate> dates)
        => _dates = dates;

    public async Task AddAsync(HistoricalDate historicalDate)
        => await _dates.InsertOneAsync(historicalDate);

    public async Task<IEnumerable<HistoricalDate>> FindAsync(Interval? interval = default!, string[] tags = default!)
    {
        var filterBuilder = Builders<HistoricalDate>.Filter;
        
        var filter = FilterDefinition<HistoricalDate>.Empty;

        if (interval is not null)
            filter &=
                filterBuilder.Gte(d => d.BeginDayNumber, interval.BeginDayNumber) &
                filterBuilder.Lte(d => d.EndDayNumber, interval.EndDayNumber);

        if (tags is not null && tags.Any())
            filter &= filterBuilder.All(d => d.Tags, tags);

        var sorter = Builders<HistoricalDate>
            .Sort
            .Ascending(d => d.BeginDayNumber)
            .Descending(d => d.EndDayNumber);

        var foundDates = await _dates
            .Find(filter)
            .Sort(sorter)
            .ToListAsync();

        return foundDates;
    }

    public async Task UpdateAsync(HistoricalDate newHistoricalDate)
         => await _dates.ReplaceOneAsync(d => d.Id == newHistoricalDate.Id, newHistoricalDate);

    public async Task DeleteAsync(Guid id)
        => await _dates.DeleteOneAsync(d => d.Id == id);
}