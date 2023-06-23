namespace App.Application.Addresses.Dtos.CreateDto;

public class StreetCreateDto : app.core.EntityAndDtoStructure.DtoStructure.CreateDto
{

    public string? StreetName { get; set; }
    public string? StreetNumber { get; set; }
    public CityCreateDto? City { get; set; }

}