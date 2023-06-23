using app.core.EntityAndDtoStructure.EntityStructure;
using App.core;
using App.core.Filter;
using App.core.InjectionHelper;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
// ReSharper disable once RedundantExtendsListEntry

namespace App.Data.GenericRepository.ReadRepository
{
    public class ReadRepository<TEntity> : Share.ReadRepository<TEntity>, IReadRepository<TEntity>, IAutoInjection
    where TEntity : Entity

    {
        public ReadRepository(DbContext context) : base(context) { }

        public TEntity GetById(int id) => Table.FirstOrDefault(x => x.Id == id)!;

        public async Task<TEntity> GetByIdAsync(int id) => (await Table.FirstOrDefaultAsync(x => x.Id == id))!;

        public List<TEntity> GetAll(IFilter<TEntity>? filter) => filter!.ApplyFilter(Table).ToList();

        public async Task<List<TEntity>> GetAllAsync(IFilter<TEntity>? filter) => await filter!.ApplyFilter(Table).ToListAsync();

        public TEntity Find(Expression<Func<TEntity, bool>> condition) => (Table.SingleOrDefault(condition))!;

        public async Task<TEntity> FindAsync(Expression<Func<TEntity, bool>> condition) => (await Table.SingleOrDefaultAsync(condition))!;

        public IEnumerable<TEntity> FindAll(Expression<Func<TEntity, bool>> condition) => Table.Where(condition);

        public async Task<IEnumerable<TEntity>> FindAllAsync(Expression<Func<TEntity, bool>> condition) => await Task.FromResult(Table.Where(condition));

        public bool Any(Expression<Func<TEntity, bool>> condition) => Table.Any(condition);

        public async Task<bool> AnyAsync(Expression<Func<TEntity, bool>> condition) => await Table.AnyAsync(condition);

        public int Count(Expression<Func<TEntity, bool>> condition) => Table.Count(condition);

        public async Task<int> CountAsync(Expression<Func<TEntity, bool>> condition) => await Table.CountAsync(condition);

    }

}
// ReSharper disable once RedundantExtendsListEntry
namespace App.Data.GenericRepository.ReadRepository.Include
{
    public class ReadRepository<TEntity, TInclude> : ReadRepository.Share.ReadRepository<TEntity>, IReadRepository<TEntity, TInclude>, IAutoInjection
    where TEntity : Entity
    where TInclude : BaseInclude<TEntity>, new()
    {
        private readonly TInclude _include;


        public ReadRepository(DbContext context) : base(context) { _include = new TInclude(); }


        private IQueryable<TEntity> ApplyInclude(string[] include) => _include.ApplyInclude(Table, include);


        public TEntity GetById(int id, string[]? include) => _include.ApplyInclude(Table, include).FirstOrDefault(x => x.Id == id)!;


        public async Task<TEntity> GetByIdAsync(int id, string[]? include)
            => (await _include.ApplyInclude(Table, include).FirstOrDefaultAsync(x => x.Id == id))!;


        public List<TEntity> GetAll(string[]? include, IFilter<TEntity>? filter)
            => filter!.ApplyFilter(ApplyInclude(include!)).ToList();


        public async Task<List<TEntity>> GetAllAsync(string[]? include, IFilter<TEntity>? filter)
            => await filter!.ApplyFilter(ApplyInclude(include!)).ToListAsync();


        public TEntity Find(Expression<Func<TEntity, bool>> condition, string[]? include)
            => _include.ApplyInclude(Table, include).SingleOrDefault(condition)!;

        public async Task<TEntity> FindAsync(Expression<Func<TEntity, bool>> condition, string[]? include)
            => (await _include.ApplyInclude(Table, include).SingleOrDefaultAsync(condition))!;

        public IEnumerable<TEntity> FindAll(Expression<Func<TEntity, bool>> condition, string[]? include)
            => _include.ApplyInclude(Table, include).Where(condition);

        public async Task<IEnumerable<TEntity>> FindAllAsync(Expression<Func<TEntity, bool>> condition, string[]? include)
        => await Task.FromResult(_include.ApplyInclude(Table, include).Where(condition));

        public bool Any(Expression<Func<TEntity, bool>> condition, string[]? include) => _include.ApplyInclude(Table, include).Any(condition);

        public async Task<bool> AnyAsync(Expression<Func<TEntity, bool>> condition, string[]? include)
        => (await _include.ApplyInclude(Table, include).AnyAsync(condition))!;

        public int Count(Expression<Func<TEntity, bool>> condition, string[]? include) => _include.ApplyInclude(Table, include).Count(condition);

        public async Task<int> CountAsync(Expression<Func<TEntity, bool>> condition, string[]? include)
        => await _include.ApplyInclude(Table, include).CountAsync(condition);

    }

}
// ReSharper disable once RedundantExtendsListEntry
namespace App.Data.GenericRepository.ReadRepository.Include.Filter
{
    public class ReadRepository<TEntity, TInclude, TFilter> : ReadRepository.Share.ReadRepository<TEntity>, IReadRepository<TEntity, TInclude, TFilter>, IAutoInjection
    where TEntity : Entity
    where TInclude : BaseInclude<TEntity>, new()
    where TFilter : Filter<TEntity>, new()
    {
        private readonly TInclude _include;
        private readonly TFilter _filter;

        public ReadRepository(DbContext context) : base(context)
        {
            _filter = new TFilter();
            _include = new TInclude();
        }


        public TEntity GetById(int id, string[]? include) => _filter.ApplyFilter(_include.ApplyInclude(Table, include)).FirstOrDefault(x => x.Id == id)!;


        public async Task<TEntity> GetByIdAsync(int id, string[]? include)
            => (await _filter.ApplyFilter(_include.ApplyInclude(Table, include)).FirstOrDefaultAsync(x => x.Id == id))!;


        public List<TEntity> GetAll(string[]? include, IFilter<TEntity>? filter)
            => filter!.ApplyFilter(ApplyInclude(include!)).ToList();



        public async Task<List<TEntity>> GetAllAsync(string[]? include, IFilter<TEntity>? filter)
            => await filter!.ApplyFilter(_filter.ApplyFilter(ApplyInclude(include!))).ToListAsync();



        private IQueryable<TEntity> ApplyInclude(string[] include) => _filter.ApplyFilter(_include.ApplyInclude(Table, include));



        public TEntity Find(Expression<Func<TEntity, bool>> condition, string[]? include)
            => (_filter.ApplyFilter(_include.ApplyInclude(Table, include)).SingleOrDefault(condition))!;


        public async Task<TEntity> FindAsync(Expression<Func<TEntity, bool>> condition, string[]? include)
            => (await _filter.ApplyFilter(_include.ApplyInclude(Table, include)).SingleOrDefaultAsync(condition))!;


        public IEnumerable<TEntity> FindAll(Expression<Func<TEntity, bool>> condition, string[]? include)
            => _filter.ApplyFilter(_include.ApplyInclude(Table, include)).Where(condition);


        public async Task<IEnumerable<TEntity>> FindAllAsync(Expression<Func<TEntity, bool>> condition, string[]? include)
        => await Task.FromResult(_filter.ApplyFilter(_include.ApplyInclude(Table, include)).Where(condition));


        public bool Any(Expression<Func<TEntity, bool>> condition, string[]? include) => _filter.ApplyFilter(_include.ApplyInclude(Table, include)).Any(condition);


        public async Task<bool> AnyAsync(Expression<Func<TEntity, bool>> condition, string[]? include)
        => (await _filter.ApplyFilter(_include.ApplyInclude(Table, include)).AnyAsync(condition))!;


        public int Count(Expression<Func<TEntity, bool>> condition, string[]? include) => _filter.ApplyFilter(_include.ApplyInclude(Table, include)).Count(condition);


        public async Task<int> CountAsync(Expression<Func<TEntity, bool>> condition, string[]? include)
        => await _filter.ApplyFilter(_include.ApplyInclude(Table, include)).CountAsync(condition);

    }

}
// ReSharper disable once RedundantExtendsListEntry
namespace App.Data.GenericRepository.ReadRepository.Filter
{
    public class ReadRepository<TEntity, TFilter> : Share.ReadRepository<TEntity>, IReadRepository<TEntity, TFilter>, IAutoInjection
    where TEntity : Entity
    where TFilter : Filter<TEntity>, new()
    {
        private readonly TFilter _filter;
        public ReadRepository(DbContext context) : base(context)
        {
            _filter = new TFilter();
        }

        public TEntity GetById(int id) => _filter.ApplyFilter(Table).FirstOrDefault(x => x.Id == id)!;

        public async Task<TEntity> GetByIdAsync(int id) => (await _filter.ApplyFilter(Table).FirstOrDefaultAsync(x => x.Id == id))!;

        public List<TEntity> GetAll(IFilter<TEntity>? filter) => filter!.ApplyFilter(_filter.ApplyFilter(Table)).ToList();

        public async Task<List<TEntity>> GetAllAsync(IFilter<TEntity>? filter) => await filter!.ApplyFilter(_filter.ApplyFilter(Table)).ToListAsync();

        public TEntity Find(Expression<Func<TEntity, bool>> condition) => (_filter.ApplyFilter(Table).SingleOrDefault(condition))!;

        public async Task<TEntity> FindAsync(Expression<Func<TEntity, bool>> condition) => (await _filter.ApplyFilter(Table).SingleOrDefaultAsync(condition))!;

        public IEnumerable<TEntity> FindAll(Expression<Func<TEntity, bool>> condition) => _filter.ApplyFilter(Table).Where(condition);

        public async Task<IEnumerable<TEntity>> FindAllAsync(Expression<Func<TEntity, bool>> condition) => await Task.FromResult(_filter.ApplyFilter(Table).Where(condition));

        public bool Any(Expression<Func<TEntity, bool>> condition) => _filter.ApplyFilter(Table).Any(condition);

        public async Task<bool> AnyAsync(Expression<Func<TEntity, bool>> condition) => await _filter.ApplyFilter(Table).AnyAsync(condition);

        public int Count(Expression<Func<TEntity, bool>> condition) => _filter.ApplyFilter(Table).Count(condition);

        public async Task<int> CountAsync(Expression<Func<TEntity, bool>> condition) => await _filter.ApplyFilter(Table).CountAsync(condition);

    }

}

namespace App.Data.GenericRepository.ReadRepository.Share
{
    public class ReadRepository<TEntity> : IReadRepository<TEntity>
    where TEntity : Entity
    {
        protected readonly DbSet<TEntity> Table;

        protected ReadRepository(DbContext context)
        {
            Table = context.Set<TEntity>();
        }
        public int Count() => Table.Count();
        public async Task<int> CountAsync() => await Task.FromResult(Table.Count());
        public async Task<bool> ExistsAsync(int id) => await Table.AnyAsync(e => e.Id == id);
        public bool Exists(int id) => Table.Any(e => e.Id == id);

    }

}
