namespace HistoricalDates.Domain.DateModel.Base;

public static class ProlepticGregorianСalendar
{
    private const int _daysInJanuary = 31;

    public static int DayNumber(int day, int month, int year, Era era)
        => DayNumber(new Day(day, month, year, era));

    public static int DayNumber(Day day)
    {
        var dayNumberInYear = DayNumberInYear(day);

        if (day.Era is Era.BC)
        {
            var daysToYear = DaysToYear(day.Year, day.Era);

            return -(daysToYear - dayNumberInYear + 1);
        }

        var daysToPreviousYear = DaysToYear(day.Year - 1, day.Era);

        return daysToPreviousYear + dayNumberInYear;
    }

    public static int DaysInMonth(int month, int year, Era era)
    {
        if (month == 2)
            return IsLeapYear(year, era) ? 29 : 28;

        return DateTime.DaysInMonth(year, month);
    }

    private static int DayNumberInYear(Day day)
    {
        var days = day.Month switch
        {
            1 => day.Value,
            2 => _daysInJanuary + day.Value,
            3 => DaysBeforeMarch(day.Year, day.Era) + day.Value,
            _ => DaysBeforeMarch(day.Year, day.Era) + DaysFromMarchToDay(day)
        };

        return days;
    }

    private static int DaysFromMarchToDay(Day day)
        => DaysBetwenTwoDates(new DateTime(day.Year, 3, 1), new DateTime(day.Year, day.Month, day.Value));

    private static int DaysBeforeMarch(int year, Era era)
        => _daysInJanuary + DaysInMonth(2, year, era);

    private static int DaysBetwenTwoDates(DateTime from, DateTime to)
        => (to - from).Days + 1;

    private static int DaysToYear(int year, Era era)
        => year * 365 + LeapYearsToYear(year, era);

    private static int LeapYearsToYear(int year, Era era)
    {
        var leapsYears = year / 4 - year / 100 + year / 400;

        if (era is Era.AD)
            return leapsYears;

        if (year % 400 == 0)
            return leapsYears;

        if (year % 100 == 0)
            return leapsYears + 1;

        if (year % 4 == 0)
            return leapsYears;

        return leapsYears + 1;
    }

    private static bool IsLeapYear(int year, Era era)
    {
        if (era is Era.BC)
        {
            if (year == 1)
                return true;

            year--;
        }

        return DateTime.IsLeapYear(year);
    }
}