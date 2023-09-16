using HistoricalDates.Application.Dtos.DateValue;

namespace HistoricalDates.Application.Dtos.Date;

public record SingleDateDto(
    IDateValueDto DateValue, 
    string Description,
    string[] Tags
) : IDateDto;