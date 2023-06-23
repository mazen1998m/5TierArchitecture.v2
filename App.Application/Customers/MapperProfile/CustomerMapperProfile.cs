using app.Domain.Humans.Customers;
using App.Application.Customers.Dtos.CreateDto;
using App.Application.Customers.Dtos.ShowDto;
using AutoMapper;

namespace App.Application.Customers.MapperProfile;

public class CustomerMapperProfile : Profile
{
    public CustomerMapperProfile()
    {
        CreateMap<Customer, CustomerShowDto>();

        CreateMap<CustomerCreateDto, Customer>();

    }
}