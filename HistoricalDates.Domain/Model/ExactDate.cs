using MongoDB.Bson.Serialization.Attributes;

namespace HistoricalDates.Domain.Model;

public sealed record ExactDate : SingleDate
{
    public int Day { get; init; }
    public int Month { get; init; }
    public int Year { get; init; }
}