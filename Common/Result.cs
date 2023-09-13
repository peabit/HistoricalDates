namespace Common;

public record Result
{
    public bool IsSuccess { get; private init; }

    public bool IsFailure => !IsSuccess;

    public IEnumerable<string> Messages => _messages;

    public static Result Success()
        => new(success: true);

    public static Result Failure(IEnumerable<string> messages)
        => new(success: false, messages);

    public static Result Failure(string message)
        => new(success: false, messages: new List<string> { message });

    public static Result<T> Success<T>(T value)
        => new(success: true, value);

    public static Result<T> Failure<T>(IEnumerable<string> messages)
        => new(success: false, messages: messages);

    public static Result<T> Failure<T>(string message)
        => new(success: false, messages: new List<string> { message });

    protected Result(bool success, IEnumerable<string> messages = default!)
    {
        IsSuccess = success;
        _messages = messages ?? new List<string>();
    }

    private readonly IEnumerable<string> _messages;
}

public sealed record Result<T> : Result
{
    public T Value { get; private init; }

    internal Result(
        bool success, T value = default!, IEnumerable<string> messages = default!) : base(success, messages)
    {
        Value = value;
    }
}