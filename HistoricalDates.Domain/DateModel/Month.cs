using HistoricalDates.Domain.DateModel.Base;

namespace HistoricalDates.Domain.DateModel;

public sealed record Month : Date
{
    public Month(int month, int year, Era era = default) : base(era)
    {
        Year = Rules.EnsureValidYear(year);
        Value = Rules.EnsureValidMonth(month, year);
    }

    public int Value { get; private init; }

    public int Year { get; private init; }

    public override Interval ToInterval()
    {
        var beginDayNumber = ProlepticGregorianСalendar.DayNumber(day: 1, month: Value, Year, Era);

        var daysInMonth = ProlepticGregorianСalendar.DaysInMonth(month: Value, Year, Era);

        var endDayNumber = ProlepticGregorianСalendar.DayNumber(day: daysInMonth, month: Value, Year, Era);

        return new Interval(beginDayNumber, endDayNumber);
    }

    protected override string DateToString() 
        => $"{MonthNameProvider.Get(Value)} {Year}";
}