using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace App.core.ValidatorHelper;

public static class ValidateResult
{
    public static List<ValidatorError> GetValidationResult<T>(T objectToValidate, out bool isValid)
    {

        var results = GetValidator<T>().Validate(objectToValidate);
        var errorList = results.Errors.Select(x => new ValidatorError
        {
            PropertyName = x.PropertyName,
            ErrorMessage = x.ErrorMessage
        }).ToList();
        isValid = results.IsValid;
        return errorList;
    }

    private static IValidator<TValidator> GetValidator<TValidator>()
    {
        var serviceProvider = new ServiceCollection()
            .AddValidatorsFromAssembly(Assembly.GetExecutingAssembly()).BuildServiceProvider();
        var validator = serviceProvider.GetRequiredService<IValidator<TValidator>>();
        return validator;
    }


    public static List<ValidatorError> Errors<TDto>(TDto createDto, out bool isValid)
    {
        var validatorError = ValidatorError.CreateList();
        isValid = true;

        try
        {
            validatorError = ValidateResult.GetValidationResult(createDto, out isValid);
        }
        catch (InvalidOperationException)
        {
            ValidatorError.DefaultError(validatorError);
        }

        return validatorError;
    }




}