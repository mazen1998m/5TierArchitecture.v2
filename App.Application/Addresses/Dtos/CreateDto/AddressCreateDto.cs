
namespace App.Application.Addresses.Dtos.CreateDto;
using app.core.EntityAndDtoStructure.DtoStructure;
public class AddressCreateDto : CreateDto
{
    public string? HouseNumber { get; set; }

    public string? ZipCode { get; set; }

    public StreetCreateDto? Street { get; set; }

}

