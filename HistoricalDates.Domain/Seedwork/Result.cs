namespace HistoricalDates.Domain.Seedwork;

public record Result
{
    public bool IsSuccess { get; private init; }

    public bool IsError => !IsSuccess;

    public string? Message { get; private init; }

    public static Result Success() => new(true);

    public static Result Error(string message) => new(false, message);

    protected Result(bool success, string? message = null)
    {
        IsSuccess = success;
        Message = message;
    }
}

public sealed record Result<T> : Result
{
    public T Value { get; private init; }

    public static Result<T> Success(T value) => new(true, value);

    public static Result<T> Error(T value, string message) => new(false, value, message);

    private Result(bool success, T value, string? message = null)
        : base(success, message)
    {
        Value = value;
    }
}