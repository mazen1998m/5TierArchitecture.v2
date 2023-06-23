using app.core.EntityAndDtoStructure.DtoStructure;
using FluentValidation;

namespace App.core.ValidatorHelper;

public class DtoValidator<T> : AbstractValidator<T> where T : CreateDto
{
    public DtoValidator()
    {
        RuleFor(x => x.Description)
            .MaximumLength(500)
            .WithMessage("The maximum length is 500 characters");
    }
}
