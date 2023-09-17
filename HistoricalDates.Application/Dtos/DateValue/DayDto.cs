using System.ComponentModel.DataAnnotations;

namespace HistoricalDates.Application.Dtos.DateValue;

public record DayDto(
    [Required] int Day,
    int Month,
    int Year,
    string? Era,
    bool? Circa   
) : IDateValueDto;