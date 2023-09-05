using HistoricalDates.Domain.DateModel.Base;

namespace HistoricalDates.Domain.DateModel;

public sealed record Day : SingleDate, IComparable<Day>
{
    public Day(int day, int month, int year, Era era = default) : base(era)
    {
        Value = day;
        Month = month;
        Year = year;
    }

    public int Value { get; private init; }

    public int Month { get; private init; }

    public int Year { get; private init; }

    public int CompareTo(Day? other)
    {
        if (other is null) 
            return 1;

        if ((this.Era, other.Era) is (Era.AD, Era.BC))
            return 1;

        if ((this.Era, other.Era) is (Era.BC, Era.AD))
            return -1;

        var result = CompareWithoutEra(other);

        return Era is Era.AD ? result : result * -1;
    }

    public static bool operator >(Day a, Day b)
    => a.CompareTo(b) > 0;

    public static bool operator <(Day a, Day b)
        => a.CompareTo(b) < 0;

    protected override Interval InitInterval()
        => new(beginDay: this, endDay: this);

    private int CompareWithoutEra(Day other)
    {
        if (Year > other.Year)
            return 1;

        if (Year < other.Year)
            return -1;

        if (Month > other.Month)
            return 1;

        if (Month < other.Month)
            return -1;

        if (Value > other.Value)
            return 1;

        if (Value < other.Value)
            return -1;

        return 0;
    }
}