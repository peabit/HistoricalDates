namespace HistoricalDates.Domain.DateModel.Base;

internal static class Rules
{
    public static void EnsureThat(bool condition, string message)
    {
        if (condition is false) throw new DomainException(message);
    }

    public static T EnsureThat<T>(bool condition, T value, string message)
        => condition ? value : throw new DomainException(message);

    public static string EnsureThatStringIsNotEmpty(string value, string name)
        => EnsureThat(!String.IsNullOrEmpty(value), value, $"{name} should be is not empty");

    public static int EnsureValidDay(int day, int month, int year, Era era)
    {
        var daysInMonth = ProlepticGregorianСalendar.DaysInMonth(month, year, era);

        return EnsureThatValueInRange(day, from: 1, to: daysInMonth, "Day");
    }

    public static int EnsureThatValueGreaterThanZero(int value, string name)
        => EnsureThat(value > 0, value, $"{name} should be positive");

    public static int EnsureValidMonth(int month, int year)
        => EnsureThatValueInRange(month, from: 1, to: 12, "Month");

    public static int EnsureValidYear(int year)
        => EnsureThatValueGreaterThanZero(year, "Year");

    public static int EnsureValidCentury(int century)
        => EnsureThatValueGreaterThanZero(century, "Century");

    private static int EnsureThatValueInRange(int value, int from, int to, string name)
        => EnsureThat(value >= from && value <= to, value, $"{name} should be in range {from} - {to}");
}