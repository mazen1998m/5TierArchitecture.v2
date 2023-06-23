using app.core.EntityAndDtoStructure.DtoStructure;
using App.core;
using App.core.ResultStructure;

namespace App.Application;

public interface ICrud<in TCreateDto, TShowDto>
where TCreateDto : CreateDto
where TShowDto : ShowDto
{
    Result<TShowDto> GetById(int id);
    Result<List<TShowDto>> GetAll();
    Result<TShowDto> Find(string filter);
    Result<TShowDto> Create(TCreateDto dto);
    void Update(TCreateDto dto);
    void Delete(int id);
}