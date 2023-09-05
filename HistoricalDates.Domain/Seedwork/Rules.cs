//using HistoricalDates.Domain.DateModel.Base;

//namespace HistoricalDates.Domain.Seedwork;

//public class Rule<T>
//{
//    private readonly T _value;
//    private readonly bool _condition;
//    private readonly string _message;

//    internal Rule(T value, bool condition, string message)
//    {
//        _value = value;
//        _condition = condition;
//        _message = message ?? throw new ArgumentNullException(nameof(message));
//    }

//    public Result Check()
//        => _condition ? Result.Success() : Result.Error(_message);

//    internal T Ensure()
//        => _condition ? _value : throw new DomainException(_message);
//}

//public static class Rules
//{
//    public static Rule<int> Day(int day, int month, int year, Era era)
//    {
//        var daysInMonth = DateModel.Month.DaysInMonth(month, year, era);

//        return ShouldBeInRange(day, from: 1, to: daysInMonth, nameof(day));
//    }

//    public static Rule<int> Month(int month) => ShouldBeInRange(month, from: 1, to: 12, nameof(month));

//    public static Rule<int> Year(int year) => ShouldBeGreaterThanZero(year, nameof(year));

//    public static Rule<int> Century(int century) => ShouldBeGreaterThanZero(century, nameof(century));

//    private static Rule<int> ShouldBeGreaterThanZero(int value, string name) 
//        => new(value, value > 0, $"{name} should be positive");

//    private static Rule<int> ShouldBeInRange(int value, int from, int to, string name) 
//        => new(value, value >= from && value <= to, $"{name} should be in range {from} - {to}");
//}