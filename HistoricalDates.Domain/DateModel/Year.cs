using HistoricalDates.Domain.DateModel.Base;

namespace HistoricalDates.Domain.DateModel;

public sealed record Year : Date
{
    public Year(int year, Era era = default) : base(era)
        => Value = Rules.EnsureValidYear(year);

    public int Value { get; private init; }

    public override Interval ToInterval()
    {
        var beginDayNumber = ProlepticGregorianСalendar.DayNumber(day: 1, month: 1, year: Value, Era);
        var endDayNumber = ProlepticGregorianСalendar.DayNumber(day: 31, month: 12, year: Value, Era);

        return new Interval(beginDayNumber, endDayNumber);
    }

    protected override string DateToString()  => Value.ToString();
}