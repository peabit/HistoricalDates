using Common;


namespace HistoricalDates.WebAPI;

public static class Mapper
{
    //public static void Map(DateDto date)
    //{
    //    if (date.Type is "period")
    //    {
    //        MapPeriod(date);
    //    }

    //    MapSingleDate(date);
    //}

    //private static Result<IDateDto> MapSingleDate(BaseDateDto date)
    //    => date.Type!.ToLower() switch
    //    {
    //        "day" => MapDay(date),
    //        _ => throw new InvalidOperationException("")
    //    };

    //private static void MapPeriod(DateDto date)
    //{
    //    // validate base

    //    // d1 MapDate
    //    // d2 MapDate

    //    // succes
    //}

    //private static Result<IDateDto> MapDay(BaseDateDto date)
    //{
    //    var validationResult = new DayDtoValidator().Validate(date);

    //    if (validationResult.IsValid)
    //    {
    //        var day = new DayDto(date.Day!.Value, date.Month!.Value, date.Year!.Value);

    //        return Result.Success<IDateDto>(day);
    //    }

    //    return Result.Failure<IDateDto>(validationResult.Errors.Select(x => x.ErrorMessage));
    //}
}