using System.Globalization;

namespace HistoricalDates.Domain.DateModel.Base;

internal static class MonthNameProvider
{
    public static string Get(int month)
        => CultureInfo.GetCultureInfo("en").DateTimeFormat.GetMonthName(month);
}