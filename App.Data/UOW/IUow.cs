using app.core.EntityAndDtoStructure.EntityStructure;
using App.core;
using App.core.Filter;
using App.core.InjectionHelper;
using App.Data.GenericRepository.ReadRepository;
using App.Data.GenericRepository.ReadRepository.Include;
using App.Data.GenericRepository.ReadRepository.Include.Filter;
using App.Data.GenericRepository.WriteRepository;
using App.Data.GenericRepository.WriteRepository.Include;

namespace App.Data.UOW
{
    public interface IUow<TEntity> : Share.IUow<TEntity>, IAutoInjection
    where TEntity : Entity


    {

        ReadRepository<TEntity> Read { get; set; }
        WriteRepository<TEntity> Write { get; set; }

    }
}

namespace App.Data.UOW.Include

{
    public interface IUow<TEntity, TInclude> : Share.IUow<TEntity>, IAutoInjection
        where TEntity : Entity
        where TInclude : BaseInclude<TEntity>, new()

    {
        ReadRepository<TEntity, TInclude> Read { get; set; }
        WriteRepository<TEntity, TInclude> Write { get; set; }
    }
}

namespace App.Data.UOW.Filter
{
    public interface IUow<TEntity, TFilter> : Share.IUow<TEntity>, IAutoInjection
        where TEntity : Entity
        where TFilter : Filter<TEntity>, new()

    {
        GenericRepository.ReadRepository.Filter.ReadRepository<TEntity, TFilter> Read { get; set; }
        WriteRepository<TEntity> Write { get; set; }

    }
}

namespace App.Data.UOW.Include.Filter
{
    public interface IUow<TEntity, TInclude, TFilter> : Share.IUow<TEntity>, IAutoInjection
        where TEntity : Entity
        where TInclude : BaseInclude<TEntity>, new()
        where TFilter : Filter<TEntity>, new()

    {

        ReadRepository<TEntity, TInclude, TFilter> Read { get; set; }
        WriteRepository<TEntity, TInclude> Write { get; set; }
    }
}

namespace App.Data.UOW.Share
{
    public interface IUow<TEntity>
        where TEntity : Entity

    {

        void Dispose();
        int Save();
        Task SaveAsync();
        Task<int> ExecuteSqlInterpolatedAsync(FormattableString sql);
        int ExecuteSqlInterpolated(FormattableString sql);
        int ExecuteSqlRaw(string sql, params object[] parameters);
        Task<int> ExecuteSqlRawAsync(string sql, params object[] parameters);
    }
}