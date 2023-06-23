using App.Application.Persons.Dtos.CreateDto;
using FluentValidation;

namespace App.Application.Persons.Validator;

public class EmailDtoValidator : AbstractValidator<EmailCreateDto>
{
    public EmailDtoValidator()
    {
        RuleFor(x => x.EmailAddress)
            .EmailAddress().When(p => p.EmailAddress != null)
            .WithMessage("The email address is not valid");


    }
}
