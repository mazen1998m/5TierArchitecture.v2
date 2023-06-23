namespace App.Application.Addresses.Dtos.CreateDto
{
    public class CityCreateDto : app.core.EntityAndDtoStructure.DtoStructure.CreateDto
    {

        public string? CityName { get; set; }
        public CountryCreateDto? Country { get; set; }
    }
}