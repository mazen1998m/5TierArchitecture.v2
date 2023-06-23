using app.Domain.Addresses;
using App.Application.Addresses.Dtos.CreateDto;
using App.Application.Addresses.Dtos.ShowDto;
using AutoMapper;

namespace App.Application.Addresses.MapperProfile;

public class AddressesMapperProfile : Profile
{
    public AddressesMapperProfile()
    {
        #region ShowMapper

        CreateMap<Address, AddressShowDto>();

        CreateMap<City, CityShowDto>();

        CreateMap<Country, CountryShowDto>();

        CreateMap<Street, StreetShowDto>();

        #endregion

        #region CreateMapper

        CreateMap<AddressCreateDto, Address>();

        CreateMap<CityCreateDto, City>();

        CreateMap<CountryCreateDto, Country>();

        CreateMap<StreetCreateDto, Street>();

        #endregion


    }

}