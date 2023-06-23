
namespace App.Application.Addresses.Dtos.ShowDto;

public class AddressShowDto : app.core.EntityAndDtoStructure.DtoStructure.ShowDto
{
    public StreetShowDto? Street { get; set; }
    public string? HouseNumber { get; set; }

    public string? ZipCode { get; set; }

}

