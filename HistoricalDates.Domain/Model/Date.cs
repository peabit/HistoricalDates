using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace HistoricalDates.Domain.Model;

public abstract record Date
{
    public Guid Id { get; init; }

    public string Description { get; init; }

    public IEnumerable<string> Tags { get; init; }
}