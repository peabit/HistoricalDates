namespace HistoricalDates.Application.Dtos.DateValue;
 
public sealed record YearDto(
    int Year,
    string? Era,
    bool? Circa
) : IDateValueDto;