using HistoricalDates.Application.Dtos.Date;
using HistoricalDates.Application.Dtos.DateValue;
using HistoricalDates.Domain;
using HistoricalDates.Domain.DateModel;
using HistoricalDates.Domain.DateModel.Base;
using HistoricalDates.Domain.HistoricalDate;

namespace HistoricalDates.Application;

public class Mapper
{
    public HistoricalDate MapHistoricalDate(IDateDto dateDto)
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

        Date date = dateValueDto switch
        {
            DayDto dayDto 
                => new Day(dayDto.Day, dayDto.Month, dayDto.Year, era),
            
            MonthDto monthDto 
                => new Month(monthDto.Month, monthDto.Year, era),
            
            YearDto yearDto 
                => new Year(yearDto.Year, era),
            
            CenturyDto centuryDto 
                => new Century(centuryDto.Century, era),
            
            _ 
                => throw new InvalidOperationException("Unexpected date value DTO type")
        };

        return date;
    }

    public Century MapCentury(int century)
    {
        var era = Era.AD;

        if (century < 1)
        {
            century = Math.Abs(century);
            era = Era.BC;
        }

        return new Century(century, era);
    }

    private static HistoricalDate CreateSingleHistoricalDate(SingleDateDto singleDateDto)
    {
        var date = MapDateValueDto(singleDateDto.DateValue);
        
        var circa = ParseCirca(singleDateDto.DateValue.Circa);

        return HistoricalDate.CreateByDate(date, singleDateDto.Description, singleDateDto.Tags, circa);
    }
    
    private static HistoricalDate CreatePeriodHistoricalDate(PeriodDateDto periodDateDto)
    {
        var beginDate = MapDateValueDto(periodDateDto.BeginDate);

        var endDate = MapDateValueDto(periodDateDto.EndDate);

        var period = new Period<Date, Date>(beginDate, endDate);

        var historicalDate = HistoricalDate.CreateByPeriod(
            period,
            periodDateDto.Description,
            periodDateDto.Tags,
            circaBegin: ParseCirca(periodDateDto.BeginDate.Circa),
            circaEnd: ParseCirca(periodDateDto.EndDate.Circa)
        );

        return historicalDate;
    }    
    
    private static Era ParseEra(string? era)
    {
        if (era is null) return Era.AD;
        
        var success = Enum.TryParse<Era>(era, out var parsedEra);

        return success ? parsedEra : throw new DomainException("Era should be AD or BC");
    }

    private static bool ParseCirca(bool? circa) => circa ?? false;
}