//using app.core;
//using app.core.EntityAndDtoStructure.EntityStructure;
//using App.Data.EFCore;
//using Microsoft.EntityFrameworkCore;
//using System.Linq.Expressions;

//namespace App.Data.GenericRepository.BaseRepository;

//public class BaseRepository<TEntity> : IAutoInjection, IBaseRepository<TEntity> where TEntity : Entity
//{
//    private readonly DbSet<TEntity> _table;

//    public BaseRepository(EfDbContext context)
//    {
//        _table = context.Set<TEntity>();

//    }


//    public Result<TEntity> GetById(int id)
//    {
//        return Result<TEntity>.CreateResult(_table.FirstOrDefault(x => x.Id == id)!);
//    }


//    public async Task<TEntity?> GetByIdAsync(int id, string[]? includes = null)
//    {
//        if (includes == null)
//            return await Task.FromResult(_table.FirstOrDefault(x => x.Id == id));

//        IQueryable<TEntity> query = _table;

//        query = includes.Aggregate(query, (current, include)
//            => current.Include(include));

//        return await Task.FromResult(query.FirstOrDefault(x => x.Id == id));

//    }

//    public List<TEntity> GetAll(string[]? includes = null)
//    {

//        if (includes == null)
//            return _table.ToList();

//        IQueryable<TEntity> query = _table;

//        query = includes.Aggregate(query, (current, include)
//            => current.Include(include));

//        return query.ToList();
//    }

//    public async Task<List<TEntity>> GetAllAsync(string[]? includes = null)
//    {

//        if (includes == null) return await Task.FromResult(_table.ToList());

//        IQueryable<TEntity> query = _table;

//        query = includes.Aggregate(query, (current, include)
//            => current.Include(include));

//        return await Task.FromResult(query.ToList());
//    }


//    public IEnumerable<TEntity> FindAll(Expression<Func<TEntity, bool>> condition, string[]? includes = null)
//    {
//        if (includes == null) return _table.Where(condition);

//        IQueryable<TEntity> query = _table;

//        query = includes.Aggregate(query, (current, include)
//            => current.Include(include));

//        return query.Where(condition);
//    }

//    public async Task<IEnumerable<TEntity>> FindAllAsync(Expression<Func<TEntity, bool>> condition, string[]? includes = null)
//    {
//        if (includes == null) return await Task.FromResult(_table.Where(condition));

//        IQueryable<TEntity> query = _table;

//        query = includes.Aggregate(query, (current, include)
//            => current.Include(include));

//        return await Task.FromResult(query.Where(condition));
//    }

//    public TEntity? Find(Expression<Func<TEntity, bool>> condition, string[]? includes = null)
//    {
//        if (includes == null) return _table.SingleOrDefault(condition);

//        IQueryable<TEntity> query = _table;

//        query = includes.Aggregate(query, (current, include)
//            => current.Include(include));

//        return query.SingleOrDefault(condition);
//    }

//    public async Task<TEntity?> FindAsync(Expression<Func<TEntity, bool>> condition, string[]? includes = null)
//    {
//        if (includes == null) return await Task.FromResult(_table.SingleOrDefault(condition));

//        IQueryable<TEntity> query = _table;

//        query = includes.Aggregate(query, (current, include)
//            => current.Include(include));

//        return await Task.FromResult(query.SingleOrDefault(condition));
//    }

//    public bool Any(Expression<Func<TEntity, bool>> condition)
//    {
//        return _table.Any(condition);
//    }


//    public async Task<bool> AnyAsync(Expression<Func<TEntity, bool>> condition)
//    {
//        return await Task.FromResult(_table.Any(condition));
//    }

//    public int Count()
//    {
//        return _table.Count();
//    }

//    public int Count(Expression<Func<TEntity, bool>> condition)
//    {
//        return _table.Count(condition);
//    }

//    public async Task<int> CountAsync()
//    {
//        return await Task.FromResult(_table.Count());
//    }

//    public async Task<int> CountAsync(Expression<Func<TEntity, bool>> condition)
//    {
//        return await Task.FromResult(_table.Count(condition));
//    }

//    public async Task<bool> ExistsAsync(int id)
//    {
//        return await _table.AnyAsync(e => e.Id == id);
//    }

//    public bool Exists(int id)
//    {
//        return _table.Any(e => e.Id == id);
//    }


//    public void Add(TEntity entity)
//    {
//        _table.Add(entity);
//    }

//    public void AddAsync(TEntity entity)
//    {
//        _table.AddAsync(entity);
//    }

//    public void AddRange(IEnumerable<TEntity> entities)
//    {
//        _table.AddRange(entities);
//    }

//    public void AddRangeAsync(IEnumerable<TEntity> entities)
//    {
//        _table.AddRangeAsync(entities);
//    }

//    public void Remove(TEntity entity)
//    {
//        _table.Remove(entity);
//    }

//    public void RemoveRange(IEnumerable<TEntity> entities)
//    {
//        _table.RemoveRange(entities);
//    }

//    public void Update(TEntity entity)
//    {
//        _table.Update(entity);
//    }

//    public void UpdateRange(IEnumerable<TEntity> entities)
//    {
//        _table.UpdateRange(entities);
//    }

//    public IEnumerable<TEntity> FromSqlInterpolated(FormattableString sql)
//    {
//        return _table.FromSqlInterpolated(sql);
//    }


//}