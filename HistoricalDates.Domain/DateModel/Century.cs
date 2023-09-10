using HistoricalDates.Domain.DateModel.Base;

namespace HistoricalDates.Domain.DateModel;

public sealed record Century : Date
{
    public Century(int century, Era era = default) : base(era)
        => Value = Rules.EnsureValidCentury(century);

    public int Value { get; private init; }

    public override Interval ToInterval()
    {
        var yearA = (Value - 1) * 100 + 1;
        var yearB = Value * 100;

        (int beginYear, int endYear) = Era is Era.AD ? (yearA, yearB) : (yearB, yearA);

        var beginDayNumber = ProlepticGregorianСalendar.DayNumber(day: 1, month: 1, year: beginYear, Era);
        var endDayNumber = ProlepticGregorianСalendar.DayNumber(day: 31, month: 12, year: endYear, Era);

        return new Interval(beginDayNumber, endDayNumber);
    }

    protected override string DateToString()
        => RomanNumerals.Convert.ToRomanNumerals(Value);
}