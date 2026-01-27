namespace CleanArchitecture.Application.Shared;

public class Result
{
    public bool IsSuccess { get; }
    public List<string> Errors { get; }
    public bool IsFailure => !IsSuccess;

    protected Result(bool isSuccess, List<string> errors)
    {
        IsSuccess = isSuccess;
        Errors = errors;
    }

    public static Result Success() => new(true, new());
    public static Result Failure(List<string> errors) => new(false, errors);
}

public class Result<TValue> : Result
{
    public TValue? Value { get; }

    protected Result(TValue? value, bool isSuccess, List<string> errors)
        : base(isSuccess, errors)
    {
        Value = value;
    }

    public static Result<TValue> Success(TValue value) => new(value, true, new());
    public static new Result<TValue> Failure(List<string> errors) => new(default, false, errors);
}
