namespace HistoricalDates.Domain.Model;

public record SingleDate : Date
{
    public Era Era { get; init; } = Era.AD;

    public bool Circa { get; init; }
}