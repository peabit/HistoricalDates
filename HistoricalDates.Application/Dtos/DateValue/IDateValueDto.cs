namespace HistoricalDates.Application.Dtos.DateValue;

public interface IDateValueDto
{
    string? Era { get; init; }
    
    bool? Circa { get; init; }
}