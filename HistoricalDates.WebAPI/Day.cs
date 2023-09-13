namespace HistoricalDates.WebAPI;

public enum DateValueType
{
    DayDto,
    MonthDto
}

public interface IDateValue { }

public sealed record DayDto(int Day) : IDateValue { }

public sealed record MonthDto(int Month) : IDateValue { }

public enum DateType
{
    SingleDate,
    Period
}

public interface IDate { }

public sealed record SingleDate(IDateValue date) : IDate { }

public sealed record Period(IDateValue from, IDateValue to) : IDate { } 