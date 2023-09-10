namespace HistoricalDates.Domain.DateModel.Base;

public sealed record Interval
{
    public Interval(int beginDayNumber, int endDayNumber)
    {
        Rules.EnsureThat(beginDayNumber <= endDayNumber, "Begin day should be less than or equal to end day");

        BeginDayNumber = beginDayNumber;
        EndDayNumber = endDayNumber;
    }

    public int BeginDayNumber { get; private init; }

    public int EndDayNumber { get; private init; }
}