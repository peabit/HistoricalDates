namespace HistoricalDates.Domain.DateModel.Base;

public record Interval : IComparable<Interval>
{
    public Interval(Day beginDay, Day endDay)
    {
        BeginDay = beginDay ?? throw new ArgumentNullException(nameof(beginDay));
        EndDay = endDay ?? throw new ArgumentNullException(nameof(endDay));
    }

    public Day BeginDay { get; private init; }

    public Day EndDay { get; private init; }

    public int CompareTo(Interval? other)
    {
        if (other is null) return 1;

        if (BeginDay > other.BeginDay)
            return -1;

        if (BeginDay < other.BeginDay)
            return 1;

        if (EndDay > other.EndDay)
            return 1;

        if (EndDay < other.EndDay)
            return -1;

        return 0;
    }
}