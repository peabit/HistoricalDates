using HistoricalDates.Domain.DateModel.Base;

namespace HistoricalDates.Domain.DateModel;

public sealed record Month : SingleDate
{
    public Month(int month, int year, Era era = default) : base(era)
    {
        Value = month;
        Year = year;
    }

    public int Value { get; private init; }

    public int Year { get; private init; }

    public static int DaysInMonth(int month, int year, Era era)
    {
        if (era is Era.AD)
            return DateTime.DaysInMonth(year, month);

        if (month == 2)
            return 29;

        return 31;
    }

    protected override Interval InitInterval()
        => new(
            beginDay: new Day(day: 1, month: Value, Year), 
            endDay: GetLastDayOfMonth()
        );

    private Day GetLastDayOfMonth()
    {
        var daysInMonth = DaysInMonth(month: Value, Year, Era);
        
        return new Day(day: daysInMonth, month: Value, Year, Era);
    }
}