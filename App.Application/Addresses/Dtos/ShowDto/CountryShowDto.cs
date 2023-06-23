namespace App.Application.Addresses.Dtos.ShowDto;

public class CountryShowDto : app.core.EntityAndDtoStructure.DtoStructure.ShowDto
{
    public string? CountryName { get; set; }
    public string? CountryCode { get; set; }

}
