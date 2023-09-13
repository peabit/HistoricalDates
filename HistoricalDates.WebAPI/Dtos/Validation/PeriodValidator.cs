//using FluentValidation;

//namespace HistoricalDates.WebAPI.Dtos.Validation;

//public class PeriodValidator : AbstractValidator<DateDto>
//{
//    public PeriodValidator()
//    {
//        When(d => d.Type is "period", () =>
//        {
//            //RuleFor(d => d.FromDate)
//            //    .Cascade(CascadeMode.Stop)
//            //    .NotNull()
//            //    .SetValidator(new PeriodDateValidator("FromDate")!);

//            //RuleFor(d => d.ToDate)
//            //    .Cascade(CascadeMode.Stop)
//            //    .NotNull()
//            //    .SetValidator(new PeriodDateValidator("ToDate")!);
//        });
//    }
//}