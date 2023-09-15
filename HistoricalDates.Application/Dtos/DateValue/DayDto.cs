namespace HistoricalDates.Application.Dtos.DateValue;

public sealed record DayDto(
    int Day,
    int Month,
    int Year,
    string Era,
    bool Circa = default    
) : IDateValueDto;