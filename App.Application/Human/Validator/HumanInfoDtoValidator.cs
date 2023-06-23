using App.Application.Human.Dtos.CreateDto;
using App.core.ValidatorHelper;
using FluentValidation;

namespace App.Application.Human.Validator;

public class HumanInfoDtoValidator : DtoValidator<HumanCreateDto>
{
    public HumanInfoDtoValidator()
    {
        RuleFor(x => x.Name).NotEmpty().WithMessage("Name is required");

        RuleFor(h => h.Age)
            .Must(a => a is < 100).When(a => a.Age != default)
            .Must(a => a is > 18).When(a => a.Age != default)
            .WithMessage("Age must be less than 100 and at least 18 years old");

        RuleFor(h => h.Gender)
            .Must(a => a is "male" or "female").When(p => p.Gender != default)
            .WithMessage("the gender must be male or female");

    }

}