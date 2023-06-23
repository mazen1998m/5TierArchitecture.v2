using App.Application.Addresses.Dtos.ShowDto;
using App.Application.Taxes.Dtos.ShowDto;

namespace App.Application.Companies.Dtos.ShowDto;
using app.core.EntityAndDtoStructure.DtoStructure;
public class CompanyShowDto : ShowDto
{
    public string? Name { get; set; }
    public TaxShowDto? Tax { get; set; }
    public AddressShowDto? Address { get; set; }

}