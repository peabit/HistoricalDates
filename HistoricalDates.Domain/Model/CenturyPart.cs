using MongoDB.Bson.Serialization.Attributes;

namespace HistoricalDates.Domain.Model;

public sealed record CenturyPart : SingleDate
{
    public CenturyPartValue Part { get; init; }
    public int Century { get; init; }

    public enum CenturyPartValue
    {
        TheFirstHalf,
        TheMiddle,
        TheLastHalf
    }
}