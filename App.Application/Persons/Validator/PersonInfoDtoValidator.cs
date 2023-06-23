using App.Application.Addresses.Validator;
using App.Application.Persons.Dtos.CreateDto;
using App.core.ValidatorHelper;
using FluentValidation;

namespace App.Application.Persons.Validator;

public class PersonInfoDtoValidator : DtoValidator<PersonCreateDto>
{
    public PersonInfoDtoValidator()
    {

        RuleFor(x => x.Address).SetValidator(new AddressesDtoValidator()!).When(p => p.Address != null);
        RuleFor(x => x.PhoneNumber).SetValidator(new PhoneDtoValidator()!).When(p => p.PhoneNumber != null);
        RuleFor(x => x.Email).SetValidator(new EmailDtoValidator()!).When(p => p.Email != null);

    }

}