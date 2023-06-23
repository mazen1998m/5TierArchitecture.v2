namespace App.Application.Addresses.Dtos.CreateDto;
public class CountryCreateDto : app.core.EntityAndDtoStructure.DtoStructure.CreateDto
{
    public string? CountryName { get; set; }
    public string? CountryCode { get; set; }

}
