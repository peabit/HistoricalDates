using HistoricalDates.Application.Dtos.DateValue;

namespace HistoricalDates.Application.Dtos.Date;

public record PeriodDateDto(
    IDateValueDto BeginDate,
    IDateValueDto EndDate,
    string Description
) : IDateDto;