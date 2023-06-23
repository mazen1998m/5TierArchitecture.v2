namespace App.Application.Addresses.Dtos.ShowDto
{
    public class CityShowDto : app.core.EntityAndDtoStructure.DtoStructure.ShowDto
    {
        public CountryShowDto? Country { get; set; }
        public string? CityName { get; set; }
    }
}