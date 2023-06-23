using app.core.EntityAndDtoStructure.EntityStructure;
using App.core;
using App.core.Filter;
using App.core.InjectionHelper;
using App.Data.GenericRepository.ReadRepository;
using App.Data.GenericRepository.ReadRepository.Include;
using App.Data.GenericRepository.WriteRepository;
using App.Data.GenericRepository.WriteRepository.Include;

namespace App.Data.GenericRepository.BaseRepository
{
    // ReSharper disable once RedundantExtendsListEntry
    public interface IBaseRepository<TEntity> : IWriteRepository<TEntity>, IReadRepository<TEntity>, IAutoInjection where TEntity : Entity { }
}

namespace App.Data.GenericRepository.BaseRepository.Include
{
    public interface IBaseRepository<TEntity, TInclude> :
        // ReSharper disable once RedundantExtendsListEntry
        IWriteRepository<TEntity, TInclude>, IReadRepository<TEntity, TInclude>, IAutoInjection
        where TEntity : Entity
        where TInclude : BaseInclude<TEntity>, new()
    { }
}

namespace App.Data.GenericRepository.BaseRepository.Filter
{
    public interface IBaseRepository<TEntity, TFilter> :
        // ReSharper disable once RedundantExtendsListEntry
        IWriteRepository<TEntity>, ReadRepository.Filter.IReadRepository<TEntity, TFilter>, IAutoInjection
        where TEntity : Entity
        where TFilter : Filter<TEntity>, new()
    { }
}

namespace App.Data.GenericRepository.BaseRepository.Include.Filter
{
    public interface IBaseRepository<TEntity, TInclude, TFilter> :
        IWriteRepository<TEntity, TInclude>, ReadRepository.Include.Filter.IReadRepository<TEntity, TInclude, TFilter>, IAutoInjection
        where TEntity : Entity
        where TInclude : BaseInclude<TEntity>, new()
        where TFilter : Filter<TEntity>, new()
    { }
}


