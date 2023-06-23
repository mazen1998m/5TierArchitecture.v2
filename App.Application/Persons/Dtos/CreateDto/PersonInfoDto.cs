using App.Application.Addresses.Dtos.CreateDto;

namespace App.Application.Persons.Dtos.CreateDto;
using app.core.EntityAndDtoStructure.DtoStructure;
public class PersonCreateDto : CreateDto
{
    public int? CivilNumber { get; set; }
    public AddressCreateDto? Address { get; set; }

    public PhoneCreateDto? PhoneNumber { get; set; }

    public EmailCreateDto? Email { get; set; }


}
