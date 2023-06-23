using app.core.EntityAndDtoStructure.DtoStructure;
using app.core.EntityAndDtoStructure.EntityStructure;
using App.core;
using App.core.Filter;
using App.core.InjectionHelper;
using App.core.ResultStructure;
using System.Linq.Expressions;

namespace App.Application.GenericService.ReadService
{
    public interface IReadService<TEntity, TShowDto> : Share.IReadService, IAutoInjection
    where TEntity : Entity
    where TShowDto : ShowDto
    {
        public Result<TEntity> GetById(int id);

        public Result<TMap> GetById<TMap>(int id) where TMap : ShowDto;

        public Task<Result<TEntity>> GetByIdAsync(int id);

        public Task<Result<TMap>> GetByIdAsync<TMap>(int id) where TMap : ShowDto;

        public Result<List<TEntity>> GetAll(IFilter<TEntity>? filter);

        public Result<List<TMap>> GetAll<TMap>(IFilter<TEntity>? filter) where TMap : ShowDto;

        public Task<Result<List<TEntity>>> GetAllAsync(IFilter<TEntity>? filter);

        public Task<Result<List<TMap>>> GetAllAsync<TMap>(IFilter<TEntity>? filter);

        public Result<IEnumerable<TEntity>> FindAll(Expression<Func<TEntity, bool>> condition);

        public Task<Result<IEnumerable<TEntity>>> FindAllAsync(Expression<Func<TEntity, bool>> condition);

        public Result<TEntity> Find(Expression<Func<TEntity, bool>> condition);

        public Task<Result<TEntity>> FindAsync(Expression<Func<TEntity, bool>> condition);

        public bool Any(Expression<Func<TEntity, bool>> condition);

        public Task<bool> AnyAsync(Expression<Func<TEntity, bool>> condition);

        public int Count(Expression<Func<TEntity, bool>> condition);

        public Task<int> CountAsync(Expression<Func<TEntity, bool>> condition);




    }
}

namespace App.Application.GenericService.ReadService.Include
{
    public interface IReadService<TEntity, TShowDto, TInclude> : Share.IReadService, IAutoInjection
    where TEntity : Entity
    where TShowDto : ShowDto
    where TInclude : BaseInclude<TEntity>, new()
    {
        public Result<TEntity> GetById(int id, string[]? include);

        public Result<TMap> GetById<TMap>(int id, string[]? include) where TMap : ShowDto;

        public Task<Result<TEntity>> GetByIdAsync(int id, string[]? include);

        public Task<Result<TMap>> GetByIdAsync<TMap>(int id, string[]? include) where TMap : ShowDto;

        public Result<List<TEntity>> GetAll(string[]? include, IFilter<TEntity>? filter);

        public Result<List<TMap>> GetAll<TMap>(string[]? include, IFilter<TEntity>? filter) where TMap : ShowDto;

        public Task<Result<List<TEntity>>> GetAllAsync(string[]? include, IFilter<TEntity>? filter);

        public Task<Result<List<TMap>>> GetAllAsync<TMap>(string[]? include, IFilter<TEntity>? filter);

        public Result<IEnumerable<TEntity>> FindAll(Expression<Func<TEntity, bool>> condition, string[]? include);

        public Task<Result<IEnumerable<TEntity>>> FindAllAsync(Expression<Func<TEntity, bool>> condition, string[]? include);

        public Result<TEntity> Find(Expression<Func<TEntity, bool>> condition, string[]? include);

        public Task<Result<TEntity>> FindAsync(Expression<Func<TEntity, bool>> condition, string[]? include);


        public bool Any(Expression<Func<TEntity, bool>> condition, string[]? include);

        public Task<bool> AnyAsync(Expression<Func<TEntity, bool>> condition, string[]? include);

        public int Count(Expression<Func<TEntity, bool>> condition, string[]? include);

        public Task<int> CountAsync(Expression<Func<TEntity, bool>> condition, string[]? include);


    }
}

namespace App.Application.GenericService.ReadService.Filter
{
    public interface IReadService<TEntity, TShowDto, TFilter> : Share.IReadService, IAutoInjection
    where TEntity : Entity
    where TShowDto : ShowDto
    where TFilter : Filter<TEntity>, new()
    {
        public Result<TEntity> GetById(int id);

        public Result<TMap> GetById<TMap>(int id) where TMap : ShowDto;

        public Task<Result<TEntity>> GetByIdAsync(int id);

        public Task<Result<TMap>> GetByIdAsync<TMap>(int id) where TMap : ShowDto;

        public Result<List<TEntity>> GetAll(IFilter<TEntity>? filter);

        public Result<List<TMap>> GetAll<TMap>(IFilter<TEntity>? filter) where TMap : ShowDto;

        public Task<Result<List<TEntity>>> GetAllAsync(IFilter<TEntity>? filter);

        public Task<Result<List<TMap>>> GetAllAsync<TMap>(IFilter<TEntity>? filter);

        public Result<IEnumerable<TEntity>> FindAll(Expression<Func<TEntity, bool>> condition);

        public Task<Result<IEnumerable<TEntity>>> FindAllAsync(Expression<Func<TEntity, bool>> condition);

        public Result<TEntity> Find(Expression<Func<TEntity, bool>> condition);

        public Task<Result<TEntity>> FindAsync(Expression<Func<TEntity, bool>> condition);


        public bool Any(Expression<Func<TEntity, bool>> condition);

        public Task<bool> AnyAsync(Expression<Func<TEntity, bool>> condition);

        public int Count(Expression<Func<TEntity, bool>> condition);

        public Task<int> CountAsync(Expression<Func<TEntity, bool>> condition);

    }
}

namespace App.Application.GenericService.ReadService.Include.Filter
{
    public interface IReadService<TEntity, TShowDto, TInclude, TFilter> : Share.IReadService, IAutoInjection
    where TEntity : Entity
    where TShowDto : ShowDto
    where TInclude : BaseInclude<TEntity>, new()
    where TFilter : Filter<TEntity>, new()
    {
        public Result<TEntity> GetById(int id, string[]? include);

        public Result<TMap> GetById<TMap>(int id, string[]? include) where TMap : ShowDto;

        public Task<Result<TEntity>> GetByIdAsync(int id, string[]? include);

        public Task<Result<TMap>> GetByIdAsync<TMap>(int id, string[]? include) where TMap : ShowDto;

        public Result<List<TEntity>> GetAll(string[]? include, IFilter<TEntity>? filter);

        public Result<List<TMap>> GetAll<TMap>(string[]? include, IFilter<TEntity>? filter) where TMap : ShowDto;

        public Task<Result<List<TEntity>>> GetAllAsync(string[]? include, IFilter<TEntity>? filter);

        public Task<Result<List<TMap>>> GetAllAsync<TMap>(string[]? include, IFilter<TEntity>? filter);

        public Result<IEnumerable<TEntity>> FindAll(Expression<Func<TEntity, bool>> condition, string[]? include);

        public Task<Result<IEnumerable<TEntity>>> FindAllAsync(Expression<Func<TEntity, bool>> condition, string[]? include);

        public Result<TEntity> Find(Expression<Func<TEntity, bool>> condition, string[]? include);

        public Task<Result<TEntity>> FindAsync(Expression<Func<TEntity, bool>> condition, string[]? include);

        public bool Any(Expression<Func<TEntity, bool>> condition, string[]? include);

        public Task<bool> AnyAsync(Expression<Func<TEntity, bool>> condition, string[]? include);

        public int Count(Expression<Func<TEntity, bool>> condition, string[]? include);

        public Task<int> CountAsync(Expression<Func<TEntity, bool>> condition, string[]? include);


    }
}

namespace App.Application.GenericService.ReadService.Share
{
    public interface IReadService
    {

        public int Count();
        public Task<int> CountAsync();
        public Task<bool> ExistsAsync(int id);
        public bool Exists(int id);

    }
}


