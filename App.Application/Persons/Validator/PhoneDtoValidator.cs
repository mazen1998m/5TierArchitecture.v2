using App.Application.Persons.Dtos.CreateDto;
using App.core.ValidatorHelper;
using FluentValidation;

namespace App.Application.Persons.Validator;

public class PhoneDtoValidator : DtoValidator<PhoneCreateDto>
{
    public PhoneDtoValidator()
    {
        RuleFor(x => x.Number)
            .MaximumLength(20).When(p => p.Number != null)
            .WithMessage("Phone number cannot be longer than 20 characters");

    }

}