namespace HistoricalDates.Application.Dtos;

public sealed record DayDto(int Day, int Month, int Year) : IDateDto;