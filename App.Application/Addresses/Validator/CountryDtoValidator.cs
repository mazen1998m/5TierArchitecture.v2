using App.Application.Addresses.Dtos.CreateDto;
using App.core.ValidatorHelper;
using FluentValidation;

namespace App.Application.Addresses.Validator;

public class CountryDtoValidator : DtoValidator<CountryCreateDto>
{
    public CountryDtoValidator()
    {
        //.Custom()
        RuleFor(p => p.CountryName)
            .MaximumLength(100).When(p => p.CountryName != null)
            .WithMessage("The maximum length is 100 characters");

        //RuleFor(p => p.CountryCode)
        //    .MaximumLength(20).When(p => p.CountryCode != null)
        //    .Must(code => int.TryParse(code, out _)).When(p => p.CountryCode != null)
        //    .WithMessage("Code must be a number.");

    }

}