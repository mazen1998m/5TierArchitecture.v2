using app.core.EntityAndDtoStructure.DtoStructure;
using app.core.EntityAndDtoStructure.EntityStructure;
using App.Application.GenericService.ReadService;
using App.Application.GenericService.WriteService;
using App.core;
using App.core.Filter;
using App.core.InjectionHelper;

namespace App.Application.GenericService.BaseService
{
    public interface IService<TEntity, TCreateDto, TShowDto> : Share.IService<TEntity>, IAutoInjection
        where TEntity : Entity
        where TCreateDto : CreateDto
        where TShowDto : ShowDto
    {
        public WriteService<TEntity, TCreateDto, TShowDto> Write { get; set; }
        public ReadService<TEntity, TShowDto> Read { get; set; }

    }
}

namespace App.Application.GenericService.BaseService.Include
{
    public interface IService<TEntity, TCreateDto, TShowDto, TInclude> : Share.IService<TEntity>, IAutoInjection
        where TEntity : Entity
        where TCreateDto : CreateDto
        where TShowDto : ShowDto
        where TInclude : BaseInclude<TEntity>, new()

    {
        public WriteService.Include.WriteService<TEntity, TCreateDto, TShowDto, TInclude> Write { get; set; }
        public ReadService.Include.ReadService<TEntity, TShowDto, TInclude> Read { get; set; }

    }
}

namespace App.Application.GenericService.BaseService.Filter
{
    public interface IService<TEntity, TCreateDto, TShowDto, TFilter> : Share.IService<TEntity>, IAutoInjection
        where TEntity : Entity
        where TCreateDto : CreateDto
        where TShowDto : ShowDto
        where TFilter : Filter<TEntity>, new()
    {
        public WriteService.Filter.WriteService<TEntity, TCreateDto, TShowDto, TFilter> Write { get; set; }
        public ReadService.Filter.ReadService<TEntity, TShowDto, TFilter> Read { get; set; }

    }
}

namespace App.Application.GenericService.BaseService.Include.Filter
{
    public interface IService<TEntity, TCreateDto, TShowDto, TInclude, TFilter> : Share.IService<TEntity>, IAutoInjection
        where TEntity : Entity
        where TCreateDto : CreateDto
        where TShowDto : ShowDto
        where TInclude : BaseInclude<TEntity>, new()
        where TFilter : Filter<TEntity>, new()
    {
        public WriteService.Include.Filter.WriteService<TEntity, TCreateDto, TShowDto, TInclude, TFilter> Write { get; set; }
        public ReadService.Include.Filter.ReadService<TEntity, TShowDto, TInclude, TFilter> Read { get; set; }

    }
}

namespace App.Application.GenericService.BaseService.Share
{
    public interface IService<TEntity> where TEntity : Entity
    {
        public Task<int> ExecuteSqlInterpolatedAsync(FormattableString sql);
        public int ExecuteSqlInterpolated(FormattableString sql);
        public int ExecuteSqlRaw(string sql, params object[] parameters);
        public Task<int> ExecuteSqlRawAsync(string sql, params object[] parameters);
    }
}

