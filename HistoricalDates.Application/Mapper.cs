using HistoricalDates.Application.Dtos.Date;
using HistoricalDates.Application.Dtos.DateValue;
using HistoricalDates.Domain.DateModel;
using HistoricalDates.Domain.DateModel.Base;
using HistoricalDates.Domain.HistoricalDate;
using HistoricalDates.Domain.Seedwork;

namespace HistoricalDates.Application;

public class Mapper
{
    public HistoricalDate Map(IDateDto dateDto)
    {
        var historicalDate = dateDto switch
        {
            SingleDateDto singleDateDto => CreateSingleHistoricalDate(singleDateDto),
            PeriodDateDto periodDateDto => CreatePeriodHistoricalDate(periodDateDto),
            _ => throw new InvalidOperationException("Unexpected date DTO type")
        };

        return historicalDate;
    }

    private static Date MapDateValueDto(IDateValueDto dateValueDto)
    {
        var era = ParseEra(dateValueDto.Era);

        var date = dateValueDto switch
        {
            DayDto dayDto => new Day(dayDto.Day, dayDto.Month, dayDto.Year, era),
            _ => throw new InvalidOperationException("Unexpected date value DTO type")
        };

        return date;
    }

    private static HistoricalDate CreateSingleHistoricalDate(SingleDateDto singleDateDto)
    {
        var date = MapDateValueDto(singleDateDto.DateValue);

        return HistoricalDate.CreateByDate(
            date,
            description: singleDateDto.Description,
            circa: singleDateDto.DateValue.Circa
        );
    }
    
    private static HistoricalDate CreatePeriodHistoricalDate(PeriodDateDto periodDateDto)
    {
        var fromDate = MapDateValueDto(periodDateDto.BeginDate);

        var toDate = MapDateValueDto(periodDateDto.EndDate);

        var period = new Period<Date, Date>(fromDate, toDate);

        var historicalDate = HistoricalDate.CreateByPeriod(
            period,
            periodDateDto.Description,
            circaBegin: periodDateDto.BeginDate.Circa,
            circaEnd: periodDateDto.EndDate.Circa
        );

        return historicalDate;
    }    
    
    private static Era ParseEra(string? era)
    {
        if (era is null) return Era.AD;
        
        var success = Enum.TryParse<Era>(era, out var parsedEra);

        return success ? parsedEra : throw new DomainException("Era should be AD or BC");
    }
}