using App.Application.CreditTerms.Dtos.ShowDto;
using AutoMapper;

namespace App.Application.CreditTerms.MapperProfile;
using app.Domain.CreditTerms;
using App.Application.CreditTerms.Dtos.CreateDto;

public class CreditTermsMapperProfile : Profile
{
    public CreditTermsMapperProfile()
    {
        CreateMap<CreditTerms, CreditTermsShowDto>();
        CreateMap<CreditTermsCreateDto, CreditTerms>();

    }
}