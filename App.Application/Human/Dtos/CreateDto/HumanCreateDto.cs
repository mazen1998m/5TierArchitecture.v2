namespace App.Application.Human.Dtos.CreateDto;
using app.core.EntityAndDtoStructure.DtoStructure;
public class HumanCreateDto : CreateDto

{
    public string? Name { get; set; }

    public int Age { get; set; }

    public string? Gender { get; set; }


}