using HistoricalDates.Domain.DateModel.Base;

namespace HistoricalDates.Domain.DateModel;

public sealed record Period<TBegin, TEnd>
    where TBegin : Date
    where TEnd : Date
{
    public Period(TBegin begin, TBegin end)
    {
        ArgumentNullException.ThrowIfNull(nameof(begin));
        ArgumentNullException.ThrowIfNull(nameof(end));

        EnsureBeginGreaterThanEnd(begin, end);

        Begin = begin;
        End = end;
    }

    public TBegin Begin { get; private init; }
    
    public TBegin End { get; private init; }

    public override string ToString() => $"{Begin} — {End}";

    public Interval ToInterval()
    {
        var beginDayNumber = Begin.ToInterval().BeginDayNumber;
        var endDayNumber = End.ToInterval().EndDayNumber;

        return new Interval(beginDayNumber, endDayNumber);
    }

    private static void EnsureBeginGreaterThanEnd(TBegin begin, TBegin end)
    {
        var beginInterval = begin.ToInterval();
        var endInterval = end.ToInterval();

        Rules.EnsureThat(beginInterval.EndDayNumber <= endInterval.BeginDayNumber, "Begin date should be greater than end date");
    }
}