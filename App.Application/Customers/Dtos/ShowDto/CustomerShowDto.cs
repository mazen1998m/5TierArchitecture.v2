using App.Application.Attachments.Dtos.ShowDto;
using App.Application.Companies.Dtos.ShowDto;
using App.Application.CreditTerms.Dtos.ShowDto;
using App.Application.Persons.Dtos.ShowDto;
using App.Application.Taxes.Dtos.ShowDto;

namespace App.Application.Customers.Dtos.ShowDto;

public class CustomerShowDto : PersonShowDto
{
    public int AccountNumber { get; set; }
    public CompanyShowDto? Company { get; set; }
    public TaxShowDto? Tax { get; set; }
    public AttachmentShowDto? Attachment { get; set; }
    public CreditTermsShowDto? CreditTerms { get; set; }

}