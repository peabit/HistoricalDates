using HistoricalDates.Domain.DateModel.Base;

namespace HistoricalDates.Domain.DateModel;

public sealed record Century : SingleDate
{
    public Century(int century, Era era = default) : base(era)
        => Value = century;
    
    public int Value { get; private init; }

    protected override Interval InitInterval()
    {
        var yearA = (Value - 1) * 100 + 1;
        var yearB = (Value * 100);

        (int beginYear, int endYear) = Era is Era.AD ? (yearA, yearB) : (yearB, yearA);

        var beginDay = new Day(day: 1, month: 1, beginYear, Era);
        var endDay = new Day(day: 31, month: 12, endYear, Era);

        return new Interval(beginDay, endDay);
    }
}