//using FluentValidation;
//using FluentValidation.Results;

//namespace HistoricalDates.WebAPI.Dtos.Validation
//{
//    public class PeriodDateValidator : AbstractValidator<BaseDateDto>
//    {
//        public PeriodDateValidator()
//        {
//            RuleFor(d => d.Type)
//                .In("day", "month", "year", "century")
//                //.WithName($"{parentPropetyName}.Type")
//                .DependentRules(() => Include(new BaseDateDtoValidator()!));
//        }
//    }
//}