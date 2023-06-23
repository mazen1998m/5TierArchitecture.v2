using app.core.EntityAndDtoStructure.EntityStructure;
using App.core;
using App.core.Filter;
using App.core.InjectionHelper;
using System.Linq.Expressions;
// ReSharper disable All


namespace App.Data.GenericRepository.ReadRepository
{
    public interface IReadRepository<TEntity> : IAutoInjection, Share.IReadRepository<TEntity>
    where TEntity : Entity
    {
        /// <summary>
        /// This method getting an entity by id from a database table
        /// <example>
        /// <code>GetById(5)</code>
        /// <code>GetById(5, new string[]{nameof(Type), nameof(Type2).... } )</code>
        /// </example>
        /// </summary>
        /// <returns>
        ///     entity of type TEntity matches the <paramref name="id"/>
        ///     <br/>if send <paramref name="includes"/>
        ///     return entity of type TEntity matches the <paramref name="id"/> with specify related data
        /// </returns>
        /// <param name="id">entity id</param>
        /// <param name="include"></param>
        public TEntity GetById(int id);

        /// <summary>
        /// This method getting an entity by id from a database table
        /// <example>
        /// <code>GetByIdAsync(5)</code>
        /// <code>GetByIdAsync(5, new string[]{nameof(Type), nameof(Type2).... } )</code>
        /// </example>
        /// </summary>
        /// <returns>
        ///     entity of type TEntity matches the <paramref name="id"/>
        ///     <br/>if send <paramref name="includes"/>
        ///     return entity of type TEntity matches the <paramref name="id"/> with specify related data
        /// </returns>
        /// <param name="id">entity id</param>
        /// <param name="includes">optional parameter use to join (send a name of entities to join)</param>
        public Task<TEntity> GetByIdAsync(int id);

        /// <summary>
        /// This method getting all entity from a database table
        /// <example>
        /// <code>GetAll()</code>
        /// <code>GetAll(new string[]{nameof(Type), nameof(Type2).... } )</code>
        /// </example>
        /// </summary>
        /// <returns>
        ///     all entity of type TEntity 
        ///     <br/>if send <paramref name="includes"/>
        ///     return all entity of type TEntity with specify related data
        /// </returns>
        /// <param name="includes">optional parameter use to join (send a name of entities to join)</param>
        /// <param name="filter"></param>
        public List<TEntity> GetAll(IFilter<TEntity>? filter);

        /// <summary>
        /// This method getting all entity from a database table
        /// <example>
        /// <code>GetAllAsync()</code>
        /// <code>GetAllAsync(new string[]{nameof(Type), nameof(Type2).... } )</code>
        /// </example>
        /// </summary>
        /// <returns>
        ///     all entity of type TEntity 
        ///     <br/>if send <paramref name="includes"/>
        ///     return all entity of type TEntity with specify related data
        /// </returns>
        /// <param name="includes">optional parameter use to join (send a name of entities to join)</param>
        /// <param name="filter"></param>
        public Task<List<TEntity>> GetAllAsync(IFilter<TEntity>? filter);

        /// <summary>
        /// Retrieves all elements of type TEntity from the table that match the specified <paramref name="condition"/>.
        /// Optionally <paramref name="includes"/>  the specified navigation properties in the query.
        /// </summary>
        /// <param name="condition">The condition to filter the elements on.</param>
        /// <param name="includes">The navigation properties to include in the query.</param>
        /// <returns>An enumerable of elements of type TEntity that match the condition.</returns>
        public IEnumerable<TEntity> FindAll(Expression<Func<TEntity, bool>> condition);

        /// <summary>
        /// Asynchronously retrieves all elements of type TEntity from the table that match the specified <param name="condition">.
        /// Optionally <paramref name="includes"/> the specified navigation properties in the query.
        /// </summary>
        /// <param name="condition">The condition to filter the elements on.</param>
        /// <param name="includes">The navigation properties to include in the query.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains an enumerable of elements of type TEntity that match the condition.</returns>
        public Task<IEnumerable<TEntity>> FindAllAsync(Expression<Func<TEntity, bool>> condition);

        /// <summary>
        /// Retrieves the first element of type TEntity from the table _table that matches the specified <param name="condition">.
        /// Optionally <paramref name="includes"/> the specified navigation properties in the query.
        /// </summary>
        /// <param name="condition">The condition to filter the element on.</param>
        /// <param name="includes">The navigation properties to include in the query.</param>
        /// <returns>The first element of type TEntity that matches the condition, or null if no such element is found.</returns>
        public TEntity Find(Expression<Func<TEntity, bool>> condition);
        public Task<TEntity> FindAsync(Expression<Func<TEntity, bool>> condition);

        /// <summary>
        /// Checks if there are any entities in the database that match the given <param name="condition">.
        /// </summary>
        /// <param name="condition">A boolean expression that specifies the criteria for the entities to match.</param>
        /// <returns>True if there are any entities that match the condition, false otherwise.</returns>
        public bool Any(Expression<Func<TEntity, bool>> condition);

        /// <summary>
        /// Asynchronously checks if there are any entities in the database that match the given <param name="condition">.
        /// </summary>
        /// <param name="condition">A boolean expression that specifies the criteria for the entities to match.</param>
        /// <returns>True if there are any entities that match the condition, false otherwise.</returns>
        public Task<bool> AnyAsync(Expression<Func<TEntity, bool>> condition);

        /// <summary>
        /// Returns the number of entities in the database that match the given <param name="condition">.
        /// </summary>
        /// <param name="condition">A boolean expression that specifies the criteria for the entities to match.</param>
        /// <returns>The number of entities that match the condition.</returns>
        public int Count(Expression<Func<TEntity, bool>> condition);

        /// <summary>
        /// Asynchronously returns the number of entities in the database that match the given <param name="condition">.
        /// </summary>
        /// <param name="condition">A boolean expression that specifies the criteria for the entities to match.</param>
        /// <returns>The number of entities that match the condition.</returns>
        public Task<int> CountAsync(Expression<Func<TEntity, bool>> condition);



    }

}

namespace App.Data.GenericRepository.ReadRepository.Include
{
    public interface IReadRepository<TEntity, TInclude> : IAutoInjection, Share.IReadRepository<TEntity>
    where TEntity : Entity
    where TInclude : BaseInclude<TEntity>, new()
    {

    }

}

namespace App.Data.GenericRepository.ReadRepository.Include.Filter
{
    public interface IReadRepository<TEntity, TInclude, TFilter> : IAutoInjection, Share.IReadRepository<TEntity>
    where TEntity : Entity
    where TInclude : BaseInclude<TEntity>, new()
    where TFilter : Filter<TEntity>, new()
    {

    }

}

namespace App.Data.GenericRepository.ReadRepository.Filter
{
    public interface IReadRepository<TEntity, TFilter> : IAutoInjection, Share.IReadRepository<TEntity>
        where TEntity : Entity
        where TFilter : Filter<TEntity>, new()
    {
        /// <summary>
        /// This method getting an entity by id from a database table
        /// <example>
        /// <code>GetById(5)</code>
        /// <code>GetById(5, new string[]{nameof(Type), nameof(Type2).... } )</code>
        /// </example>
        /// </summary>
        /// <returns>
        ///     entity of type TEntity matches the <paramref name="id"/>
        ///     <br/>if send <paramref name="includes"/>
        ///     return entity of type TEntity matches the <paramref name="id"/> with specify related data
        /// </returns>
        /// <param name="id">entity id</param>
        /// <param name="include"></param>
        public TEntity GetById(int id);


        /// <summary>
        /// This method getting an entity by id from a database table
        /// <example>
        /// <code>GetByIdAsync(5)</code>
        /// <code>GetByIdAsync(5, new string[]{nameof(Type), nameof(Type2).... } )</code>
        /// </example>
        /// </summary>
        /// <returns>
        ///     entity of type TEntity matches the <paramref name="id"/>
        ///     <br/>if send <paramref name="includes"/>
        ///     return entity of type TEntity matches the <paramref name="id"/> with specify related data
        /// </returns>
        /// <param name="id">entity id</param>

        public Task<TEntity> GetByIdAsync(int id);


        /// <summary>
        /// This method getting all entity from a database table
        /// <example>
        /// <code>GetAll()</code>
        /// <code>GetAll(new string[]{nameof(Type), nameof(Type2).... } )</code>
        /// </example>
        /// </summary>
        /// <returns>
        ///     all entity of type TEntity 
        ///     return all entity of type TEntity with specify related data
        /// </returns>
        /// <param name="filter"></param>
        public List<TEntity> GetAll(IFilter<TEntity>? filter);


        /// <summary>
        /// This method getting all entity from a database table
        /// <example>
        /// <code>GetAllAsync()</code>
        /// <code>GetAllAsync(new string[]{nameof(Type), nameof(Type2).... } )</code>
        /// </example>
        /// </summary>
        /// <returns>
        ///     all entity of type TEntity 
        ///     return all entity of type TEntity with specify related data
        /// </returns>
        /// <param name="filter"></param>
        public Task<List<TEntity>> GetAllAsync(IFilter<TEntity>? filter);


        /// <summary>
        /// Retrieves all elements of type TEntity from the table that match the specified <paramref name="condition"/>.
        /// </summary>
        /// <param name="condition">The condition to filter the elements on.</param>
        /// <returns>An enumerable of elements of type TEntity that match the condition.</returns>
        public IEnumerable<TEntity> FindAll(Expression<Func<TEntity, bool>> condition);


        /// <summary>
        /// Asynchronously retrieves all elements of type TEntity from the table that match the specified <param name="condition">.
        /// </summary>
        /// <param name="condition">The condition to filter the elements on.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains an enumerable of elements of type TEntity that match the condition.</returns>
        public Task<IEnumerable<TEntity>> FindAllAsync(Expression<Func<TEntity, bool>> condition);


        /// <summary>
        /// Retrieves the first element of type TEntity from the table _table that matches the specified <param name="condition">.
        /// </summary>
        /// <param name="condition">The condition to filter the element on.</param>
        /// <returns>The first element of type TEntity that matches the condition, or null if no such element is found.</returns>
        public TEntity Find(Expression<Func<TEntity, bool>> condition);


        /// <summary>
        /// Checks if there are any entities in the database that match the given <param name="condition">.
        /// </summary>
        /// <param name="condition">A boolean expression that specifies the criteria for the entities to match.</param>
        /// <returns>True if there are any entities that match the condition, false otherwise.</returns>
        public bool Any(Expression<Func<TEntity, bool>> condition);


        /// <summary>
        /// Asynchronously checks if there are any entities in the database that match the given <param name="condition">.
        /// </summary>
        /// <param name="condition">A boolean expression that specifies the criteria for the entities to match.</param>
        /// <returns>True if there are any entities that match the condition, false otherwise.</returns>
        public Task<bool> AnyAsync(Expression<Func<TEntity, bool>> condition);


        /// <summary>
        /// Returns the number of entities in the database that match the given <param name="condition">.
        /// </summary>
        /// <param name="condition">A boolean expression that specifies the criteria for the entities to match.</param>
        /// <returns>The number of entities that match the condition.</returns>
        public int Count(Expression<Func<TEntity, bool>> condition);


        /// <summary>
        /// Asynchronously returns the number of entities in the database that match the given <param name="condition">.
        /// </summary>
        /// <param name="condition">A boolean expression that specifies the criteria for the entities to match.</param>
        /// <returns>The number of entities that match the condition.</returns>
        public Task<int> CountAsync(Expression<Func<TEntity, bool>> condition);

    }
}

namespace App.Data.GenericRepository.ReadRepository.Share
{
    public interface IReadRepository<TEntity>
    where TEntity : Entity
    {

        /// <summary>
        /// Returns the total number of entities in the database.
        /// </summary>
        /// <returns>The total number of entities in the database.</returns>
        public int Count();

        /// <summary>
        /// Asynchronously returns the total number of entities in the database.
        /// </summary>
        /// <returns>The total number of entities in the database.</returns>
        public Task<int> CountAsync();

        /// <summary>
        /// Asynchronously checks if an entity with the specified <param name="id"> exists in the database.
        /// </summary>
        /// <param name="id">The ID of the entity to check for.</param>
        /// <returns>True if an entity with the specified ID exists, false otherwise.</returns>
        public Task<bool> ExistsAsync(int id);

        /// <summary>
        /// Checks if an entity with the specified <param name="id"> exists in the database.
        /// </summary>
        /// <param name="id">The ID of the entity to check for.</param>
        /// <returns>True if an entity with the specified ID exists, false otherwise.</returns>
        public bool Exists(int id);

    }

}

namespace App.Data.GenericRepository.ReadRepository.Include.Share
{
    public interface IReadRepository<TEntity> : ReadRepository.Share.IReadRepository<TEntity>
        where TEntity : Entity
    {

        /// <summary>
        /// This method getting an entity by id from a database table
        /// <example>
        /// <code>GetById(5)</code>
        /// <code>GetById(5, new string[]{nameof(Type), nameof(Type2).... } )</code>
        /// </example>
        /// </summary>
        /// <returns>
        ///     entity of type TEntity matches the <paramref name="id"/>
        ///     <br/>if send <paramref name="includes"/>
        ///     return entity of type TEntity matches the <paramref name="id"/> with specify related data
        /// </returns>
        /// <param name="id">entity id</param>
        /// <param name="includes"></param>
        public TEntity GetById(int id, string[]? includes);

        /// <summary>
        /// This method getting an entity by id from a database table
        /// <example>
        /// <code>GetByIdAsync(5)</code>
        /// <code>GetByIdAsync(5, new string[]{nameof(Type), nameof(Type2).... } )</code>
        /// </example>
        /// </summary>
        /// <returns>
        ///     entity of type TEntity matches the <paramref name="id"/>
        ///     <br/>if send <paramref name="includes"/>
        ///     return entity of type TEntity matches the <paramref name="id"/> with specify related data
        /// </returns>
        /// <param name="id">entity id</param>
        /// <param name="includes">optional parameter use to join (send a name of entities to join)</param>
        public Task<TEntity> GetByIdAsync(int id, string[]? includes);

        /// <summary>
        /// This method getting all entity from a database table
        /// <example>
        /// <code>GetAll()</code>
        /// <code>GetAll(new string[]{nameof(Type), nameof(Type2).... } )</code>
        /// </example>
        /// </summary>
        /// <returns>
        ///     all entity of type TEntity 
        ///     <br/>if send <paramref name="includes"/>
        ///     return all entity of type TEntity with specify related data
        /// </returns>
        /// <param name="includes">optional parameter use to join (send a name of entities to join)</param>
        /// <param name="filter"></param>
        public List<TEntity> GetAll(string[]? includes, IFilter<TEntity>? filter);

        /// <summary>
        /// This method getting all entity from a database table
        /// <example>
        /// <code>GetAllAsync()</code>
        /// <code>GetAllAsync(new string[]{nameof(Type), nameof(Type2).... } )</code>
        /// </example>
        /// </summary>
        /// <returns>
        ///     all entity of type TEntity 
        ///     <br/>if send <paramref name="includes"/>
        ///     return all entity of type TEntity with specify related data
        /// </returns>
        /// <param name="includes">optional parameter use to join (send a name of entities to join)</param>
        /// <param name="filter"></param>
        public Task<List<TEntity>> GetAllAsync(string[]? includes, IFilter<TEntity>? filter);

        /// <summary>
        /// Retrieves all elements of type TEntity from the table that match the specified <paramref name="condition"/>.
        /// Optionally <paramref name="includes"/>  the specified navigation properties in the query.
        /// </summary>
        /// <param name="condition">The condition to filter the elements on.</param>
        /// <param name="includes">The navigation properties to include in the query.</param>
        /// <returns>An enumerable of elements of type TEntity that match the condition.</returns>
        public IEnumerable<TEntity> FindAll(Expression<Func<TEntity, bool>> condition, string[]? includes);

        /// <summary>
        /// Asynchronously retrieves all elements of type TEntity from the table that match the specified <param name="condition">.
        /// Optionally <paramref name="includes"/> the specified navigation properties in the query.
        /// </summary>
        /// <param name="condition">The condition to filter the elements on.</param>
        /// <param name="includes">The navigation properties to include in the query.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains an enumerable of elements of type TEntity that match the condition.</returns>
        public Task<IEnumerable<TEntity>> FindAllAsync(Expression<Func<TEntity, bool>> condition, string[]? includes);

        /// <summary>
        /// Retrieves the first element of type TEntity from the table _table that matches the specified <param name="condition">.
        /// Optionally <paramref name="includes"/> the specified navigation properties in the query.
        /// </summary>
        /// <param name="condition">The condition to filter the element on.</param>
        /// <param name="includes">The navigation properties to include in the query.</param>
        /// <returns>The first element of type TEntity that matches the condition, or null if no such element is found.</returns>
        public TEntity Find(Expression<Func<TEntity, bool>> condition, string[]? includes);


        /// <summary>
        /// Checks if there are any entities in the database that match the given <param name="condition">.
        /// </summary>
        /// <param name="condition">A boolean expression that specifies the criteria for the entities to match.</param>
        /// <param name="includes"></param>
        /// <returns>True if there are any entities that match the condition, false otherwise.</returns>
        public bool Any(Expression<Func<TEntity, bool>> condition, string[]? includes);


        /// <summary>
        /// Asynchronously checks if there are any entities in the database that match the given <param name="condition">.
        /// </summary>
        /// <param name="condition">A boolean expression that specifies the criteria for the entities to match.</param>
        /// <param name="includes"></param>
        /// <returns>True if there are any entities that match the condition, false otherwise.</returns>
        public Task<bool> AnyAsync(Expression<Func<TEntity, bool>> condition, string[]? includes);


        /// <summary>
        /// Returns the number of entities in the database that match the given <param name="condition">.
        /// </summary>
        /// <param name="condition">A boolean expression that specifies the criteria for the entities to match.</param>
        /// <param name="includes"></param>
        /// <returns>The number of entities that match the condition.</returns>
        public int Count(Expression<Func<TEntity, bool>> condition, string[]? includes);


        /// <summary>
        /// Asynchronously returns the number of entities in the database that match the given <param name="condition">.
        /// </summary>
        /// <param name="condition">A boolean expression that specifies the criteria for the entities to match.</param>
        /// <param name="includes"></param>
        /// <returns>The number of entities that match the condition.</returns>
        public Task<int> CountAsync(Expression<Func<TEntity, bool>> condition, string[]? includes);

    }

}