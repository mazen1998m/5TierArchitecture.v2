using app.Domain.Companies;
using App.Application.Companies.Dtos.CreateDto;
using App.Application.Companies.Dtos.ShowDto;
using AutoMapper;

namespace App.Application.Companies.MapperProfile;

public class CompanyMapperProfile : Profile
{
    public CompanyMapperProfile()
    {
        CreateMap<Company, CompanyShowDto>();
        CreateMap<CompanyCreateDto, Company>();
    }
}