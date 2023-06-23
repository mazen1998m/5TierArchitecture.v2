using App.Application.Taxes.Dtos.CreateDto;
using App.core.ValidatorHelper;

namespace App.Application.Taxes.Validator;

public class TaxDtoValidator : DtoValidator<TaxCreateDto>
{
    public TaxDtoValidator()
    {

    }

}