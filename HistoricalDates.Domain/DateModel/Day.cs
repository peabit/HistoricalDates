using HistoricalDates.Domain.DateModel.Base;

namespace HistoricalDates.Domain.DateModel;

public sealed record Day : Date
{
    public Day(int day, int month, int year, Era era = default) : base(era)
    {
        Year = Rules.EnsureValidYear(year);
        Month = Rules.EnsureValidMonth(month, year);
        Value = Rules.EnsureValidDay(day, month, year, era);
    }

    public int Value { get; private init; }

    public int Month { get; private init; }

    public int Year { get; private init; }

    public override Interval ToInterval()
    {
        var dayNumber = ProlepticGregorianСalendar.DayNumber(this);

        return new Interval(beginDayNumber: dayNumber, endDayNumber: dayNumber);
    }

    protected override string DateToString()
        => $"{Value} {MonthNameProvider.Get(Month)} {Year}";   
}