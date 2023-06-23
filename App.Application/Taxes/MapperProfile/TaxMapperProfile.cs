using app.Domain.Taxes;
using App.Application.Taxes.Dtos.CreateDto;
using App.Application.Taxes.Dtos.ShowDto;
using AutoMapper;

namespace App.Application.Taxes.MapperProfile;

public class TaxMapperProfile : Profile
{
    public TaxMapperProfile()
    {
        CreateMap<Tax, TaxShowDto>();
        CreateMap<TaxCreateDto, Tax>();

    }
}