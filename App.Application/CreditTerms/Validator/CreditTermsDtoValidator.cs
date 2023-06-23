using App.Application.CreditTerms.Dtos.CreateDto;
using App.core.ValidatorHelper;

namespace App.Application.CreditTerms.Validator;

public class CreditTermsDtoValidator : DtoValidator<CreditTermsCreateDto>
{
    public CreditTermsDtoValidator()
    {

    }
}