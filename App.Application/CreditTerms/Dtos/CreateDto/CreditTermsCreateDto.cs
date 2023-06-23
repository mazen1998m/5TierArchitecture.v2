namespace App.Application.CreditTerms.Dtos.CreateDto;
using app.core.EntityAndDtoStructure.DtoStructure;
public class CreditTermsCreateDto : CreateDto
{
    public double Maximum { get; set; }

    public DateTime GracePeriod { get; set; }


}