using App.Application.Attachments.Dtos.CreateDto;
using App.Application.Companies.Dtos.CreateDto;
using App.Application.CreditTerms.Dtos.CreateDto;
using App.Application.Human.Dtos.CreateDto;
using App.Application.Persons.Dtos.CreateDto;
using App.Application.Taxes.Dtos.CreateDto;

namespace App.Application.Customers.Dtos.CreateDto;
using app.core.EntityAndDtoStructure.DtoStructure;
public class CustomerCreateDto : CreateDto
{
    public int AccountNumber { get; set; }
    public HumanCreateDto HumanInfo { get; set; }
    public PersonCreateDto PersonInfo { get; set; }
    public CompanyCreateDto? Company { get; set; }
    public TaxCreateDto? Tax { get; set; }
    public AttachmentCreateDto? Attachment { get; set; }
    public CreditTermsCreateDto? CreditTerms { get; set; }

}