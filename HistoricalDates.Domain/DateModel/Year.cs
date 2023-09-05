using HistoricalDates.Domain.DateModel.Base;

namespace HistoricalDates.Domain.DateModel;

public sealed record Year : SingleDate
{
    public Year(int year, Era era = default) : base(era)
        => Value = year;

    public int Value { get; private init; }

    protected override Interval InitInterval()
        => new(
            beginDay: new Day(day: 1, month: 1, year: Value, Era),
            endDay: new Day(day: 31, month: 12, year: Value, Era)
        );
}