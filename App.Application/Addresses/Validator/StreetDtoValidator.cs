using App.Application.Addresses.Dtos.CreateDto;
using App.core.ValidatorHelper;
using FluentValidation;

namespace App.Application.Addresses.Validator;

public class StreetDtoValidator : DtoValidator<StreetCreateDto>
{
    public StreetDtoValidator()
    {
        RuleFor(p => p.City).SetValidator(new CityDtoValidator()!).When(p => p.City != null);
        RuleFor(p => p.StreetNumber).Must(number => int.TryParse(number, out _)).When(p => p.StreetNumber != null)
            .WithMessage("street number must be a number.");
        RuleFor(p => p.StreetName).MaximumLength(100).When(p => p.StreetName != null)
            .WithMessage("The maximum length is 100 characters");
    }

}