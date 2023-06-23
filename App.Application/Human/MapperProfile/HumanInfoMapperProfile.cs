using App.Application.Human.Dtos.CreateDto;
using App.Application.Human.Dtos.ShowDto;
using AutoMapper;

namespace App.Application.Human.MapperProfile;

using app.Domain.humans;
public class HumanInfoMapperProfile : Profile
{
    public HumanInfoMapperProfile()
    {
        CreateMap<Human, HumanShowDto>();
        CreateMap<HumanCreateDto, Human>();

    }
}