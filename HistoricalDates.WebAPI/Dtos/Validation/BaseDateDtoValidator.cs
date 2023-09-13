//using FluentValidation;

//namespace HistoricalDates.WebAPI.Dtos.Validation;

//public class BaseDateDtoValidator : AbstractValidator<BaseDateDto>
//{
//    public BaseDateDtoValidator()
//    {
//        RuleFor(date => date)
//            .Custom(Validate);
//    }

//    private static void Validate(BaseDateDto date, ValidationContext<BaseDateDto> context)
//    {
//        IValidator<BaseDateDto> validator = date.Type! switch
//        {
//            "day" => new DayValidator(),

//            _ => default!
//        };

//        validator?.Validate(context);
//    }
//}