//using FluentValidation;

//namespace HistoricalDates.WebAPI.Dtos.Validation;

//public class DateDtoValidator : AbstractValidator<DateDto>
//{
//    public DateDtoValidator()
//    {
//        RuleFor(date => date.Type)
//            .In("day", "month", "year", "century", "period");

//        When(date => date.Type is "period", () =>
//        {
//            RuleFor(date => date.FromDate)
//                .SetValidator(new PeriodDateValidator());
//        });


//        //RuleFor(d => d.Type)
//        //    .In("day", "month", "year", "century", "period")
//        //    .DependentRules(() =>
//        //    {
//        //        Include(new BaseDateDtoValidator());
//        //        Include(new PeriodValidator());
//        //    });

//        RuleFor(d => d.Description)
//            .NotEmpty();
//    }
//}