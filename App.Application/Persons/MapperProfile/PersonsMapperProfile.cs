using app.Domain.Humans.Persons;
using App.Application.Persons.Dtos.CreateDto;
using App.Application.Persons.Dtos.ShowDto;
using AutoMapper;

namespace App.Application.Persons.MapperProfile;

public class PersonsMapperProfile : Profile
{
    public PersonsMapperProfile()
    {
        #region Show

        CreateMap<Email, EmailShowDto>();
        CreateMap<Person, PersonShowDto>();
        CreateMap<Phone, PhoneShowDto>();

        #endregion

        #region Create

        CreateMap<EmailCreateDto, Email>();
        CreateMap<PersonCreateDto, Person>();
        CreateMap<PhoneCreateDto, Phone>();

        #endregion

    }
}