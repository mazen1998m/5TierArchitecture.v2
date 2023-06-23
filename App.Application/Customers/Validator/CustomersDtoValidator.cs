using App.Application.Attachments.Validator;
using App.Application.Companies.Validator;
using App.Application.CreditTerms.Validator;
using App.Application.Customers.Dtos.CreateDto;
using App.Application.Taxes.Validator;
using App.core.ValidatorHelper;
using FluentValidation;

namespace App.Application.Customers.Validator;

public class CustomerInfoDtoValidator : DtoValidator<CustomerCreateDto>
{
    public CustomerInfoDtoValidator()
    {
        RuleFor(c => c.Attachment).SetValidator(new AttachmentDtoValidator()!).When(p => p.Attachment != null);
        RuleFor(c => c.Company).SetValidator(new CompanyDtoValidator()!).When(p => p.Company != null);
        RuleFor(c => c.Tax).SetValidator(new TaxDtoValidator()!).When(p => p.Tax != null);
        RuleFor(c => c.CreditTerms).SetValidator(new CreditTermsDtoValidator()!).When(p => p.CreditTerms != null);
    }

}