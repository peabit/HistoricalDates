namespace HistoricalDates.Application.Dtos.DateValue;

public record CenturyDto(
    int Century,
    string? Era,
    bool? Circa
) : IDateValueDto;