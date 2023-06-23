using App.Application.Addresses.Dtos.ShowDto;
using App.Application.Human.Dtos.ShowDto;

namespace App.Application.Persons.Dtos.ShowDto;

public class PersonShowDto : HumanShowDto
{
    public int? CivilNumber { get; set; }

    public AddressShowDto? AddressDto { get; set; }

    public PhoneShowDto? PhoneNumber { get; set; }

    public EmailShowDto? Email { get; set; }


}
