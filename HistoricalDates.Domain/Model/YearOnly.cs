namespace HistoricalDates.Domain.Model;

public sealed record YearOnly : SingleDate
{
    public int Year { get; init; }
}