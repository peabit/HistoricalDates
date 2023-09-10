using HistoricalDates.Domain.DateModel.Base;
using HistoricalDates.Domain.DateModel;

namespace HistoricalDates.Domain.HistoricalDate;

public sealed record HistoricalDate
{
    public static HistoricalDate CreateByDate(Date date, string description, bool circa = default)
    {
        var stringDate = date.ToString()!;

        stringDate = AddCircaLabelIfNecessary(stringDate, circa);

        var interval = date.ToInterval();

        return new HistoricalDate(stringDate, description, interval.BeginDayNumber, interval.EndDayNumber);
    }

    public static HistoricalDate CreateByPeriod<TBegin, TEnd>(
        Period<TBegin, TEnd> period, string description, bool circaBegin = default, bool circaEnd = default
    )
        where TBegin : Date
        where TEnd : Date
    {
        var beginDate = period.Begin.ToString()!;
        beginDate = AddCircaLabelIfNecessary(beginDate, circaBegin);

        var endDate = period.End.ToString()!;
        endDate = AddCircaLabelIfNecessary(endDate, circaEnd);

        var interval = period.ToInterval();
        var date = $"{beginDate} — {endDate}";

        return new HistoricalDate(date, description, interval.BeginDayNumber, interval.EndDayNumber);
    }

    private static string AddCircaLabelIfNecessary(string date, bool circa)
        => circa ? $"c. {date}" : date;

    public HistoricalDate(string date, string description, int beginDayNumber, int endDayNaumber, Guid? id = default)
    {
        Id = id ?? Guid.NewGuid();
        Date = date;
        Description = description;
        BeginDayNumber = beginDayNumber;
        EndDayNumber = endDayNaumber;
    }

    public Guid Id { get; private init; }

    public string Date { get; private init; }

    public string Description { get; private init; }

    public int BeginDayNumber { get; private init; }

    public int EndDayNumber { get; private init; }
}