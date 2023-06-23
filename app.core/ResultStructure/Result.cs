using App.core.Extensions;
using App.core.ValidatorHelper;

namespace App.core.ResultStructure;

/// <summary>
/// Represents the result of an operation that returns an object of type <typeparamref name="TYpe"/>.
/// </summary>
/// <typeparam name="TYpe">The type of the object returned by the operation.</typeparam>
public class Result<TYpe> where TYpe : class
{

    public List<TYpe>? Response { get; set; }

    public List<string>? Error { get; set; }
    public List<ValidatorError> ValidatorError { get; set; }

    public bool IsSuccess { get; set; }



    public static Result<TYpe> CreateResult(TYpe obj) =>
              obj.IsObjEmpty()
                        ? CreateResultToNullObj()
                        : CreateResultToNotNullObj(obj);

    public static Task<Result<TYpe>> CreateResult(Task<TYpe> obj) =>
        obj.IsObjEmpty()
            ? CreateResultToNullObjAsync()
            : CreateResultToNotNullObjAsync(obj);

    public static Result<TYpe> CreateResult(List<TYpe> obj) =>
        obj.IsObjEmpty()
            ? CreateResultToNullObj()
            : CreateResultToNotNullObj(obj);


    public static Result<TYpe> CreateResult(List<ValidatorError> validatorErrors, object entity, TYpe dto
        , string errorMessage = null!)
    {
        return new Result<TYpe>
        {
            ValidatorError = validatorErrors,
            IsSuccess = entity != null!,
            Response = entity != null! ? new List<TYpe> { dto } : null,
            Error = entity == null!
                ? errorMessage == null!
                    ? new List<string> { Message.UnspecifiedError }
                    : new List<string> { errorMessage }
                : new List<string> { Message.NoError }
        };



    }





    private static async Task<Result<TYpe>> CreateResultToNotNullObjAsync(Task<TYpe> obj)
    {
        return await Task.FromResult(new Result<TYpe>
        {
            Response = new List<TYpe> { await obj },
            IsSuccess = true,
            Error = new List<string> { Message.NoError }
        });
    }

    private static async Task<Result<TYpe>> CreateResultToNullObjAsync()
    {
        return await Task.FromResult(new Result<TYpe>
        {
            Response = null!,
            IsSuccess = false,
            Error = new List<string> { Message.NotFound() }
        });
    }

    private static Result<TYpe> CreateResultToNotNullObj(TYpe obj) => new()
    {
        Response = new List<TYpe> { obj },
        IsSuccess = true,
        Error = new List<string> { Message.NoError }
    };

    private static Result<TYpe> CreateResultToNotNullObj(List<TYpe> obj) => new()
    {
        Response = obj,
        IsSuccess = true,
        Error = new List<string> { Message.NoError }
    };

    private static Result<TYpe> CreateResultToNullObj() => new()
    {
        Response = null!,
        IsSuccess = false,
        Error = new List<string> { Message.NotFound() }
    };
}

