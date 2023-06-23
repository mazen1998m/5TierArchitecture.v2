using App.Application.Addresses.Validator;
using App.Application.Companies.Dtos.CreateDto;
using App.Application.Taxes.Validator;
using App.core.ValidatorHelper;
using FluentValidation;

namespace App.Application.Companies.Validator;

public class CompanyDtoValidator : DtoValidator<CompanyCreateDto>
{
    public CompanyDtoValidator()
    {
        RuleFor(c => c.Name)
            .MaximumLength(100).When(p => p.Name != null)
            .WithMessage("The maximum length is 100 characters");
        RuleFor(c => c.Address).SetValidator(new AddressesDtoValidator()!).When(p => p.Address != null);

        RuleFor(c => c.Tax).SetValidator(new TaxDtoValidator()!).When(p => p.Tax != null);

    }

}