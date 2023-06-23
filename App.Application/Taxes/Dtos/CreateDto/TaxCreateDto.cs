namespace App.Application.Taxes.Dtos.CreateDto;

public class TaxCreateDto : app.core.EntityAndDtoStructure.DtoStructure.CreateDto
{
    public string? TaxCode { get; set; }
}