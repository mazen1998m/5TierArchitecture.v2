using App.Application.Addresses.Dtos.CreateDto;
using App.core.ValidatorHelper;
using FluentValidation;

namespace App.Application.Addresses.Validator;


public class AddressesDtoValidator : DtoValidator<AddressCreateDto>
{
    public AddressesDtoValidator()
    {
        RuleFor(p => p.Street).SetValidator(new StreetDtoValidator()!).When(p => p.Street != null);

        //RuleFor(p => p.ZipCode)
        //    .Must(zipCode => int.TryParse(zipCode, out _)).When(p => p.ZipCode != null)
        //    .WithMessage("zipCode must be a number.");

        RuleFor(p => p.HouseNumber)
            .MaximumLength(10).When(p => p.HouseNumber != null)
            .WithMessage("The maximum length is 100 characters");


    }
}