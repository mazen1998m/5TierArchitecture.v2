using App.Application.Addresses.Dtos.CreateDto;
using App.core.ValidatorHelper;
using FluentValidation;

namespace App.Application.Addresses.Validator;

public class CityDtoValidator : DtoValidator<CityCreateDto>
{
    public

        CityDtoValidator()
    {
        RuleFor(p => p.Country).SetValidator(new CountryDtoValidator()!).When(p => p.Country != null);

        RuleFor(p => p.CityName).MaximumLength(100).When(p => p.CityName != null)
            .WithMessage("The maximum length is 100 characters");

    }

}