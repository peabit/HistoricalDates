namespace HistoricalDates.Domain.DateModel.Base;

public abstract record Date : IComparable<Date>
{
    public int CompareTo(Date? other)
        => other is null ? 1 : Interval.CompareTo(other.Interval);

    internal Interval Interval 
        => _interval ??= InitInterval();

    protected abstract Interval InitInterval();

    private Interval? _interval;
}