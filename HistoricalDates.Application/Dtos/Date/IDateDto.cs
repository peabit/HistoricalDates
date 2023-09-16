namespace HistoricalDates.Application.Dtos.Date;

public interface IDateDto
{
    string Description { get; init; }

    string[] Tags { get; init; }
}