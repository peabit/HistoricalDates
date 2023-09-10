using HistoricalDates.Domain.DateModel.Base;
using HistoricalDates.Domain.DateModel;

namespace HistoricalDates.Domain.HistoricalDate;

public sealed record HistoricalDate
{
    public static HistoricalDate CreateByDate(
        Date date, 
        string description, 
        string[] tags = default!, 
        bool circa = default)
    {
        var stringDate = date.ToString()!;

        stringDate = AddCircaLabelIfNecessary(stringDate, circa);

        return new HistoricalDate(stringDate, description, date.ToInterval(), tags);
    }

    public static HistoricalDate CreateByPeriod<TBegin, TEnd>(
        Period<TBegin, TEnd> period, 
        string description, 
        string[] tags = default!, 
        bool circaBegin = default, 
        bool circaEnd = default
    )
        where TBegin : Date
        where TEnd : Date
    {
        var beginDate = period.Begin.ToString()!;
        beginDate = AddCircaLabelIfNecessary(beginDate, circaBegin);

        var endDate = period.End.ToString()!;
        endDate = AddCircaLabelIfNecessary(endDate, circaEnd);

        var date = $"{beginDate} — {endDate}";

        return new HistoricalDate(date, description, period.ToInterval(), tags);
    }

    private static string AddCircaLabelIfNecessary(string date, bool circa)
        => circa ? $"c. {date}" : date;

    public HistoricalDate(string date, string description, Interval interval, string[] tags = default!, Guid? id = default)
    {
        Id = id ?? Guid.NewGuid();
        
        Date = Rules.EnsureThatStringIsNotEmpty(date, nameof(date)); ;
        Description = Rules.EnsureThatStringIsNotEmpty(description, nameof(description));

        BeginDayNumber = interval.BeginDayNumber;
        EndDayNumber = interval.EndDayNumber;

        Tags = tags;    
    }

    public Guid Id { get; private init; }

    public string Date { get; private init; }

    public string Description { get; private init; }

    public string[] Tags { get; private init; }

    public int BeginDayNumber { get; private init; }

    public int EndDayNumber { get; private init; }
}