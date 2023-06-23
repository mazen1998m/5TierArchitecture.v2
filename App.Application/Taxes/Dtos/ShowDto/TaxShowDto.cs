namespace App.Application.Taxes.Dtos.ShowDto;

public class TaxShowDto : app.core.EntityAndDtoStructure.DtoStructure.ShowDto
{
    public string? TaxCode { get; set; }
}