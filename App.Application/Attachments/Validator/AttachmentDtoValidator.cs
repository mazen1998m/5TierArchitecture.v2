using App.Application.Attachments.Dtos.CreateDto;
using App.core.ValidatorHelper;

namespace App.Application.Attachments.Validator;


public class AttachmentDtoValidator : DtoValidator<AttachmentCreateDto>
{
    public AttachmentDtoValidator()
    {

    }
}