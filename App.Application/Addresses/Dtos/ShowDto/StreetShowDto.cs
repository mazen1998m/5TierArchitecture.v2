namespace App.Application.Addresses.Dtos.ShowDto;

public class StreetShowDto : app.core.EntityAndDtoStructure.DtoStructure.ShowDto
{
    public CityShowDto? City { get; set; }
    public string? StreetName { get; set; }
    public string? StreetNumber { get; set; }

}