using app.core.EntityAndDtoStructure.EntityStructure;
using App.core;
using App.core.InjectionHelper;

namespace App.Data.GenericRepository.WriteRepository.Include
{
    public interface IWriteRepository<TEntity, TInclude> : Share.IWriteRepository<TEntity>, IAutoInjection
        where TEntity : Entity where TInclude : BaseInclude<TEntity>, new()
    {
        #region Add

        TEntity Add(TEntity entity);
        Task<TEntity> AddAsync(TEntity entity);
        List<TEntity> AddRange(IEnumerable<TEntity> entities);
        Task<List<TEntity>> AddRangeAsync(IEnumerable<TEntity> entities);
        public TEntity SaveAdd(TEntity entity);
        public Task<TEntity> SaveAddAsync(TEntity entity);
        public List<TEntity> SaveAddRange(IEnumerable<TEntity> entities);
        public Task<List<TEntity>> SaveAddRangeAsync(IEnumerable<TEntity> entities);

        #endregion


        #region Remove

        public TEntity Remove(TEntity entity);
        public TEntity RemoveById(int id);
        public void RemoveRange(IEnumerable<TEntity> entities);
        public void SaveRemove(TEntity entity);
        public void SaveRemoveById(int id);
        public void SaveRemoveRange(IEnumerable<TEntity> entities);
        public Task SaveRemoveByIdAsync(int id);
        public Task SaveRemoveRangeAsync(IEnumerable<TEntity> entities);
        public Task SaveRemoveAsync(TEntity entity);
        #endregion


        #region Update

        public void Update(TEntity entity);
        public void SaveUpdate(TEntity entity);
        public Task SaveUpdateAsync(TEntity entity);
        public void UpdateRange(IEnumerable<TEntity> entities);
        public void SaveUpdateRange(IEnumerable<TEntity> entities);
        public Task SaveUpdateRangeAsync(IEnumerable<TEntity> entities);


        #endregion
    }
}

namespace App.Data.GenericRepository.WriteRepository
{
    public interface IWriteRepository<TEntity> : Share.IWriteRepository<TEntity>, IAutoInjection where TEntity : Entity
    {
        #region Add

        TEntity Add(TEntity entity);
        Task<TEntity> AddAsync(TEntity entity);
        List<TEntity> AddRange(IEnumerable<TEntity> entities);
        Task<List<TEntity>> AddRangeAsync(IEnumerable<TEntity> entities);
        public TEntity SaveAdd(TEntity entity);
        public Task<TEntity> SaveAddAsync(TEntity entity);
        public List<TEntity> SaveAddRange(IEnumerable<TEntity> entities);
        public Task<List<TEntity>> SaveAddRangeAsync(IEnumerable<TEntity> entities);

        #endregion


        #region Remove

        public TEntity Remove(TEntity entity);
        public TEntity RemoveById(int id);
        public void RemoveRange(IEnumerable<TEntity> entities);
        public void SaveRemove(TEntity entity);
        public void SaveRemoveById(int id);
        public void SaveRemoveRange(IEnumerable<TEntity> entities);
        public Task SaveRemoveByIdAsync(int id);
        public Task SaveRemoveRangeAsync(IEnumerable<TEntity> entities);
        public Task SaveRemoveAsync(TEntity entity);
        #endregion


        #region Update

        public void Update(TEntity entity);
        public void SaveUpdate(TEntity entity);
        public Task SaveUpdateAsync(TEntity entity);
        public void UpdateRange(IEnumerable<TEntity> entities);
        public void SaveUpdateRange(IEnumerable<TEntity> entities);
        public Task SaveUpdateRangeAsync(IEnumerable<TEntity> entities);


        #endregion
    }
}

//todo:we need to know what is the share and what is not    
namespace App.Data.GenericRepository.WriteRepository.Share
{
    public interface IWriteRepository<TEntity> :
        IAutoInjection
        where TEntity : Entity
    {
        //#region Add

        //TEntity Add(TEntity entity);
        //Task<TEntity> AddAsync(TEntity entity);
        //List<TEntity> AddRange(IEnumerable<TEntity> entities);
        //Task<List<TEntity>> AddRangeAsync(IEnumerable<TEntity> entities);
        //public TEntity SaveAdd(TEntity entity);
        //public Task<TEntity> SaveAddAsync(TEntity entity);
        //public List<TEntity> SaveAddRange(IEnumerable<TEntity> entities);
        //public Task<List<TEntity>> SaveAddRangeAsync(IEnumerable<TEntity> entities);

        //#endregion


        //#region Remove

        //public TEntity Remove(TEntity entity);
        //public TEntity RemoveById(int id);
        //public void RemoveRange(IEnumerable<TEntity> entities);
        //public void SaveRemove(TEntity entity);
        //public void SaveRemoveById(int id);
        //public void SaveRemoveRange(IEnumerable<TEntity> entities);
        //public Task SaveRemoveByIdAsync(int id);
        //public Task SaveRemoveRangeAsync(IEnumerable<TEntity> entities);
        //public Task SaveRemoveAsync(TEntity entity);
        //#endregion


        //#region Update

        //public void Update(TEntity entity);
        //public void SaveUpdate(TEntity entity);
        //public Task SaveUpdateAsync(TEntity entity);
        //public void UpdateRange(IEnumerable<TEntity> entities);
        //public void SaveUpdateRange(IEnumerable<TEntity> entities);
        //public Task SaveUpdateRangeAsync(IEnumerable<TEntity> entities);


        //#endregion



        public IEnumerable<TEntity> FromSqlInterpolated(FormattableString sql);



    }
}
