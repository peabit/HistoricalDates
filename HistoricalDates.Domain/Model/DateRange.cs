namespace HistoricalDates.Domain.Model;

public record DateRange<TFrom, TTo> : Date
{
    public TFrom From { get; init; }
    public TTo To { get; init; }
}