using FluentValidation;

namespace HistoricalDates.WebAPI;

public static class FluentValidationCustomRules
{
    public static IRuleBuilderOptions<T, string?> In<T>(this IRuleBuilder<T, string?> ruleBuilder, params string[] validOptions)
        => ruleBuilder
            .NotEmpty()
            .Must(validOptions.Contains)
            .WithMessage($"{{PropertyName}} must be one of these values: {String.Join(", ", validOptions)}");
}