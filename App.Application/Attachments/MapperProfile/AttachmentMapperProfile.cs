using app.Domain.Attachments;
using App.Application.Attachments.Dtos.CreateDto;
using App.Application.Attachments.Dtos.ShowDto;
using AutoMapper;

namespace App.Application.Attachments.MapperProfile;

public class AttachmentMapperProfile : Profile
{
    public AttachmentMapperProfile()
    {
        CreateMap<Attachment, AttachmentShowDto>();
        CreateMap<AttachmentCreateDto, Attachment>();

    }
}