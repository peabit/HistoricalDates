namespace HistoricalDates.Application.Dtos.DateValue;

public sealed record MonthDto( 
    int Month,
    int Year,
    string? Era,
    bool? Circa
) : IDateValueDto;