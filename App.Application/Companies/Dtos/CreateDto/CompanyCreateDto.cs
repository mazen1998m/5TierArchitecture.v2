using App.Application.Addresses.Dtos.CreateDto;
using App.Application.Taxes.Dtos.CreateDto;

namespace App.Application.Companies.Dtos.CreateDto;
using app.core.EntityAndDtoStructure.DtoStructure;
public class CompanyCreateDto : CreateDto
{
    public string? Name { get; set; }
    public TaxCreateDto? Tax { get; set; }
    public AddressCreateDto? Address { get; set; }

}