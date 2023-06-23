using app.core.EntityAndDtoStructure.DtoStructure;
using app.core.EntityAndDtoStructure.EntityStructure;
using App.core;
using App.core.Filter;
using App.core.InjectionHelper;
using App.core.ResultStructure;

namespace App.Application.GenericService.WriteService
{
    public interface IWriteService<TEntity, TCreateDto, TShowDto> : Share.IWriteService<TEntity>, IAutoInjection
        where TEntity : Entity
        where TCreateDto : CreateDto
        where TShowDto : ShowDto
    {
        Result<TShowDto> Create(TCreateDto createDto);
        Task<Result<TShowDto>> CreateAsync(TCreateDto createDto);
        List<Result<TShowDto>> AddRange(IEnumerable<TCreateDto> entities);
        void AddRangeAsync(IEnumerable<TEntity> entities);
        void Delete(TEntity entity);
        void RemoveRange(IEnumerable<TEntity> entities);
        void Update(TEntity entity);
        void UpdateRange(IEnumerable<TEntity> entities);
        public IEnumerable<TEntity> FromSqlInterpolated(FormattableString sql);

    }
}

namespace App.Application.GenericService.WriteService.Filter
{
    public interface IWriteService<TEntity, TCreateDto, TShowDto, TFilter> : Share.IWriteService<TEntity>, IAutoInjection
        where TEntity : Entity
        where TCreateDto : CreateDto
        where TShowDto : ShowDto
        where TFilter : Filter<TEntity>, new()
    {
        Result<TShowDto> Create(TCreateDto createDto);
        Task<Result<TShowDto>> CreateAsync(TCreateDto createDto);
        List<Result<TShowDto>> AddRange(IEnumerable<TCreateDto> entities);
        void AddRangeAsync(IEnumerable<TEntity> entities);
        void Delete(TEntity entity);
        void RemoveRange(IEnumerable<TEntity> entities);
        void Update(TEntity entity);
        void UpdateRange(IEnumerable<TEntity> entities);
        public IEnumerable<TEntity> FromSqlInterpolated(FormattableString sql);

    }
}

namespace App.Application.GenericService.WriteService.Include
{
    public interface IWriteService<TEntity, TCreateDto, TShowDto, TInclude> : Share.IWriteService<TEntity>, IAutoInjection
        where TEntity : Entity
        where TCreateDto : CreateDto
        where TShowDto : ShowDto
        where TInclude : BaseInclude<TEntity>, new()
    {
        Result<TShowDto> Create(TCreateDto createDto);
        Task<Result<TShowDto>> CreateAsync(TCreateDto createDto);
        List<Result<TShowDto>> AddRange(IEnumerable<TCreateDto> entities);
        void AddRangeAsync(IEnumerable<TEntity> entities);
        void Delete(TEntity entity);
        void RemoveRange(IEnumerable<TEntity> entities);
        void Update(TEntity entity);
        void UpdateRange(IEnumerable<TEntity> entities);
        public IEnumerable<TEntity> FromSqlInterpolated(FormattableString sql);

    }
}

namespace App.Application.GenericService.WriteService.Include.Filter
{
    public interface IWriteService<TEntity, TCreateDto, TShowDto, TInclude, TFilter> : Share.IWriteService<TEntity>, IAutoInjection
        where TEntity : Entity
        where TCreateDto : CreateDto
        where TShowDto : ShowDto
        where TInclude : BaseInclude<TEntity>, new()
        where TFilter : Filter<TEntity>, new()
    {
        Result<TShowDto> Create(TCreateDto createDto);
        Task<Result<TShowDto>> CreateAsync(TCreateDto createDto);
        List<Result<TShowDto>> AddRange(IEnumerable<TCreateDto> entities);
        void AddRangeAsync(IEnumerable<TEntity> entities);
        void Delete(TEntity entity);
        void RemoveRange(IEnumerable<TEntity> entities);
        void Update(TEntity entity);
        void UpdateRange(IEnumerable<TEntity> entities);
        public IEnumerable<TEntity> FromSqlInterpolated(FormattableString sql);

    }
}

namespace App.Application.GenericService.WriteService.Share
{
    public interface IWriteService<TEntity> where TEntity : Entity

    {

    }
}
