namespace App.Application.CreditTerms.Dtos.ShowDto;
using app.core.EntityAndDtoStructure.DtoStructure;
public class CreditTermsShowDto : ShowDto
{
    public double Maximum { get; set; }

    public DateTime GracePeriod { get; set; }


}