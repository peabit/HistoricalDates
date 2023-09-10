namespace HistoricalDates.Domain.DateModel.Base;

public sealed record Interval
{
    public Interval(int beginDay, int endDay)
    {
        Rules.EnsureThat(beginDay >= endDay, "Begin day should be less than or equal to end day");

        BeginDayNumber = beginDay;
        EndDayNumber = endDay;
    }

    public int BeginDayNumber { get; private init; }

    public int EndDayNumber { get; private init; }
}