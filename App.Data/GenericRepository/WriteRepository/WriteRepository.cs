using app.core.EntityAndDtoStructure.EntityStructure;
using App.core;
using App.core.InjectionHelper;
using Microsoft.EntityFrameworkCore;

namespace App.Data.GenericRepository.WriteRepository
{
    // ReSharper disable once RedundantExtendsListEntry
    public class WriteRepository<TEntity> : Share.WriteRepository<TEntity>, IWriteRepository<TEntity>, IAutoInjection
    where TEntity : Entity
    {

        //todo:create methods with save  like Add  and SaveAdd  Add without save and SaveAdd with save
        public WriteRepository(DbContext context) : base(context) { }

        #region Add

        public TEntity Add(TEntity entity) => Table.Add(entity).Entity;
        public async Task<TEntity> AddAsync(TEntity entity) => (await Table.AddAsync(entity)).Entity;
        public TEntity SaveAdd(TEntity entity)
        {
            var entityEntity = Table.Add(entity);
            Save();
            return entityEntity.Entity;
        }

        public async Task<TEntity> SaveAddAsync(TEntity entity)
        {
            var entityEntity = await Table.AddAsync(entity);
            await SaveAsync();
            return entityEntity.Entity;
        }


        public List<TEntity> AddRange(IEnumerable<TEntity> entities)
        {
            var addRange = entities.ToList();
            Table.AddRange(addRange);
            return addRange;
        }

        public async Task<List<TEntity>> AddRangeAsync(IEnumerable<TEntity> entities)
        {
            var addRange = entities.ToList();
            await Table.AddRangeAsync(addRange);
            return addRange;
        }

        public List<TEntity> SaveAddRange(IEnumerable<TEntity> entities)
        {
            var addRange = entities.ToList();
            Table.AddRange(addRange);
            Save();
            return addRange;
        }

        public async Task<List<TEntity>> SaveAddRangeAsync(IEnumerable<TEntity> entities)
        {
            var addRange = entities.ToList();
            await Table.AddRangeAsync(addRange);
            await SaveAsync();
            return addRange;
        }

        #endregion


        #region Remove

        public TEntity Remove(TEntity entity) => Table.Remove(entity).Entity;

        public TEntity RemoveById(int id) => Table.Remove(Table.Find(id)!).Entity;

        public void RemoveRange(IEnumerable<TEntity> entities) => Table.RemoveRange(entities);

        public void SaveRemove(TEntity entity)
        {
            Table.Remove(entity);
            Save();
        }
        public async Task SaveRemoveAsync(TEntity entity)
        {
            Table.Remove(entity);
            await SaveAsync();
        }

        public void SaveRemoveById(int id)
        {
            Table.Remove(Table.Find(id)!);
            Save();
        }
        public async Task SaveRemoveByIdAsync(int id)
        {
            Table.Remove((await Table.FindAsync(id))!);
            await SaveAsync();
        }

        public void SaveRemoveRange(IEnumerable<TEntity> entities)
        {
            Table.RemoveRange(entities);
            Save();
        }
        public async Task SaveRemoveRangeAsync(IEnumerable<TEntity> entities)
        {
            Table.RemoveRange(entities);
            await SaveAsync();
        }

        #endregion


        #region Update

        public void Update(TEntity entity) => Table.Update(entity);
        public void SaveUpdate(TEntity entity)
        {
            Table.Update(entity);
            Save();
        }
        public async Task SaveUpdateAsync(TEntity entity)
        {
            Table.Update(entity);
            await SaveAsync();
        }
        public void UpdateRange(IEnumerable<TEntity> entities) => Table.UpdateRange(entities);
        public void SaveUpdateRange(IEnumerable<TEntity> entities)
        {
            Table.UpdateRange(entities);
            Save();
        }
        public async Task SaveUpdateRangeAsync(IEnumerable<TEntity> entities)
        {
            Table.UpdateRange(entities);
            await SaveAsync();
        }

        #endregion


    }
}

namespace App.Data.GenericRepository.WriteRepository.Include
{
    // ReSharper disable once RedundantExtendsListEntry
    public class WriteRepository<TEntity, TInclude> : Share.WriteRepository<TEntity>, IWriteRepository<TEntity, TInclude>, IAutoInjection
    where TEntity : Entity
    where TInclude : BaseInclude<TEntity>, new()
    {

        //todo:create methods with save  like Add  and SaveAdd  Add without save and SaveAdd with save
        public WriteRepository(DbContext context) : base(context) { }


        #region Add

        public TEntity Add(TEntity entity) => Table.Add(entity).Entity;
        public async Task<TEntity> AddAsync(TEntity entity) => (await Table.AddAsync(entity)).Entity;
        public TEntity SaveAdd(TEntity entity)
        {
            var entityEntity = Table.Add(entity);
            Save();
            return entityEntity.Entity;
        }

        public async Task<TEntity> SaveAddAsync(TEntity entity)
        {
            var entityEntity = await Table.AddAsync(entity);
            await SaveAsync();
            return entityEntity.Entity;
        }


        public List<TEntity> AddRange(IEnumerable<TEntity> entities)
        {
            var addRange = entities.ToList();
            Table.AddRange(addRange);
            return addRange;
        }

        public async Task<List<TEntity>> AddRangeAsync(IEnumerable<TEntity> entities)
        {
            var addRange = entities.ToList();
            await Table.AddRangeAsync(addRange);
            return addRange;
        }

        public List<TEntity> SaveAddRange(IEnumerable<TEntity> entities)
        {
            var addRange = entities.ToList();
            Table.AddRange(addRange);
            Save();
            return addRange;
        }

        public async Task<List<TEntity>> SaveAddRangeAsync(IEnumerable<TEntity> entities)
        {
            var addRange = entities.ToList();
            await Table.AddRangeAsync(addRange);
            await SaveAsync();
            return addRange;
        }

        #endregion


        #region Remove

        public TEntity Remove(TEntity entity) => Table.Remove(entity).Entity;

        public TEntity RemoveById(int id) => Table.Remove(Table.Find(id)!).Entity;

        public void RemoveRange(IEnumerable<TEntity> entities) => Table.RemoveRange(entities);

        public void SaveRemove(TEntity entity)
        {
            Table.Remove(entity);
            Save();
        }
        public async Task SaveRemoveAsync(TEntity entity)
        {
            Table.Remove(entity);
            await SaveAsync();
        }

        public void SaveRemoveById(int id)
        {
            Table.Remove(Table.Find(id)!);
            Save();
        }
        public async Task SaveRemoveByIdAsync(int id)
        {
            Table.Remove((await Table.FindAsync(id))!);
            await SaveAsync();
        }

        public void SaveRemoveRange(IEnumerable<TEntity> entities)
        {
            Table.RemoveRange(entities);
            Save();
        }
        public async Task SaveRemoveRangeAsync(IEnumerable<TEntity> entities)
        {
            Table.RemoveRange(entities);
            await SaveAsync();
        }

        #endregion


        #region Update

        public void Update(TEntity entity) => Table.Update(entity);
        public void SaveUpdate(TEntity entity) => Table.Update(entity);
        public async Task SaveUpdateAsync(TEntity entity)
        {
            Table.Update(entity);
            await SaveAsync();
        }
        public void UpdateRange(IEnumerable<TEntity> entities) => Table.UpdateRange(entities);
        public void SaveUpdateRange(IEnumerable<TEntity> entities)
        {
            Table.UpdateRange(entities);
            Save();
        }
        public async Task SaveUpdateRangeAsync(IEnumerable<TEntity> entities)
        {
            Table.UpdateRange(entities);
            await SaveAsync();
        }

        #endregion


    }
}


//todo:we need to know what is the share and what is not
namespace App.Data.GenericRepository.WriteRepository.Share
{
    public class WriteRepository<TEntity> : IWriteRepository<TEntity>
    where TEntity : Entity
    {
        private readonly DbContext _context;

        //todo:create methods with save  like Add  and SaveAdd  Add without save and SaveAdd with save
        protected readonly DbSet<TEntity> Table;


        protected WriteRepository(DbContext context)
        {
            _context = context;
            Table = context.Set<TEntity>();
        }


        //#region Add

        //public TEntity Add(TEntity entity) => _table.Add(entity).Entity;
        //public async Task<TEntity> AddAsync(TEntity entity) => (await _table.AddAsync(entity)).Entity;
        //public TEntity SaveAdd(TEntity entity)
        //{
        //    var entityEntity = _table.Add(entity);
        //    Save();
        //    return entityEntity.Entity;
        //}

        //public async Task<TEntity> SaveAddAsync(TEntity entity)
        //{
        //    var entityEntity = await _table.AddAsync(entity);
        //    await SaveAsync();
        //    return entityEntity.Entity;
        //}


        //public List<TEntity> AddRange(IEnumerable<TEntity> entities)
        //{
        //    var addRange = entities.ToList();
        //    _table.AddRange(addRange);
        //    return addRange;
        //}

        //public async Task<List<TEntity>> AddRangeAsync(IEnumerable<TEntity> entities)
        //{
        //    var addRange = entities.ToList();
        //    await _table.AddRangeAsync(addRange);
        //    return addRange;
        //}

        //public List<TEntity> SaveAddRange(IEnumerable<TEntity> entities)
        //{
        //    var addRange = entities.ToList();
        //    _table.AddRange(addRange);
        //    Save();
        //    return addRange;
        //}

        //public async Task<List<TEntity>> SaveAddRangeAsync(IEnumerable<TEntity> entities)
        //{
        //    var addRange = entities.ToList();
        //    await _table.AddRangeAsync(addRange);
        //    await SaveAsync();
        //    return addRange;
        //}

        //#endregion


        //#region Remove

        //public TEntity Remove(TEntity entity) => _table.Remove(entity).Entity;

        //public TEntity RemoveById(int id) => _table.Remove(_table.Find(id)!).Entity;

        //public void RemoveRange(IEnumerable<TEntity> entities) => _table.RemoveRange(entities);

        //public void SaveRemove(TEntity entity)
        //{
        //    _table.Remove(entity);
        //    Save();
        //}
        //public async Task SaveRemoveAsync(TEntity entity)
        //{
        //    _table.Remove(entity);
        //    await SaveAsync();
        //}

        //public void SaveRemoveById(int id)
        //{
        //    _table.Remove(_table.Find(id)!);
        //    Save();
        //}
        //public async Task SaveRemoveByIdAsync(int id)
        //{
        //    _table.Remove((await _table.FindAsync(id))!);
        //    await SaveAsync();
        //}

        //public void SaveRemoveRange(IEnumerable<TEntity> entities)
        //{
        //    _table.RemoveRange(entities);
        //    Save();
        //}
        //public async Task SaveRemoveRangeAsync(IEnumerable<TEntity> entities)
        //{
        //    _table.RemoveRange(entities);
        //    await SaveAsync();
        //}

        //#endregion


        //#region Update

        //public void Update(TEntity entity) => _table.Update(entity);
        //public void SaveUpdate(TEntity entity) => _table.Update(entity);
        //public async Task SaveUpdateAsync(TEntity entity)
        //{
        //    _table.Update(entity);
        //    await SaveAsync();
        //}
        //public void UpdateRange(IEnumerable<TEntity> entities) => _table.UpdateRange(entities);
        //public void SaveUpdateRange(IEnumerable<TEntity> entities)
        //{
        //    _table.UpdateRange(entities);
        //    Save();
        //}
        //public async Task SaveUpdateRangeAsync(IEnumerable<TEntity> entities)
        //{
        //    _table.UpdateRange(entities);
        //    await SaveAsync();
        //}

        //#endregion


        public IEnumerable<TEntity> FromSqlInterpolated(FormattableString sql) => Table.FromSqlInterpolated(sql);

        protected int Save() => _context.SaveChanges();
        protected async Task SaveAsync() => await _context.SaveChangesAsync();

    }
}
