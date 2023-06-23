namespace App.Application.Human.Dtos.ShowDto;
using app.core.EntityAndDtoStructure.DtoStructure;
public class HumanShowDto : ShowDto

{
    public string? Name { get; set; }

    public int Age { get; set; }

    public string? Gender { get; set; }


}