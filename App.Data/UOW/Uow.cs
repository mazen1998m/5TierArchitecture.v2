using app.core.EntityAndDtoStructure.EntityStructure;
using App.core;
using App.core.Filter;
using App.core.InjectionHelper;
using App.Data.EFCore;
using App.Data.GenericRepository.ReadRepository;
using App.Data.GenericRepository.ReadRepository.Include;
using App.Data.GenericRepository.WriteRepository;
using App.Data.GenericRepository.WriteRepository.Include;
using Microsoft.EntityFrameworkCore;

namespace App.Data.UOW
{
    // ReSharper disable once RedundantExtendsListEntry
    public class Uow<TEntity> : Share.Uow<TEntity>, IAutoInjection, IUow<TEntity> where TEntity : Entity


    {
        public ReadRepository<TEntity> Read { get; set; }
        public WriteRepository<TEntity> Write { get; set; }
        public Uow(EfDbContext context) : base(context)
        {
            Read = new ReadRepository<TEntity>(context);
            Write = new WriteRepository<TEntity>(context);
        }


    }

}

namespace App.Data.UOW.Include
{
    // ReSharper disable once RedundantExtendsListEntry
    public class Uow<TEntity, TInclude> : Share.Uow<TEntity>, IAutoInjection,
        IUow<TEntity, TInclude> where TEntity : Entity
        where TInclude : BaseInclude<TEntity>, new()

    {
        public ReadRepository<TEntity, TInclude> Read { get; set; }
        public WriteRepository<TEntity, TInclude> Write { get; set; }
        public Uow(EfDbContext context) : base(context)
        {
            Read = new ReadRepository<TEntity, TInclude>(context);
            Write = new WriteRepository<TEntity, TInclude>(context);
        }


    }

}

namespace App.Data.UOW.Filter
{
    // ReSharper disable once RedundantExtendsListEntry
    public class Uow<TEntity, TFilter> : Share.Uow<TEntity>, IAutoInjection,
        IUow<TEntity, TFilter>
        where TEntity : Entity
        where TFilter : Filter<TEntity>, new()

    {

        public GenericRepository.ReadRepository.Filter.ReadRepository<TEntity, TFilter> Read { get; set; }
        public WriteRepository<TEntity> Write { get; set; }
        public Uow(EfDbContext context) : base(context)
        {
            Read = new GenericRepository.ReadRepository.Filter.ReadRepository<TEntity, TFilter>(context);
            Write = new WriteRepository<TEntity>(context);
        }

    }

}

namespace App.Data.UOW.Include.Filter
{
    // ReSharper disable once RedundantExtendsListEntry
    public class Uow<TEntity, TInclude, TFilter> : Share.Uow<TEntity>, IAutoInjection,
        IUow<TEntity, TInclude, TFilter> where TEntity : Entity
        where TInclude : BaseInclude<TEntity>, new()
        where TFilter : Filter<TEntity>, new()

    {
        public GenericRepository.ReadRepository.Include.Filter.ReadRepository<TEntity, TInclude, TFilter> Read { get; set; }
        public WriteRepository<TEntity, TInclude> Write { get; set; }
        public Uow(EfDbContext context) : base(context)
        {
            Read = new GenericRepository.ReadRepository.Include.Filter.ReadRepository<TEntity, TInclude, TFilter>(context);
            Write = new WriteRepository<TEntity, TInclude>(context);
        }


    }

}

namespace App.Data.UOW.Share
{
    public class Uow<TEntity> : IUow<TEntity> where TEntity : Entity


    {
        protected readonly EfDbContext Context;

        protected Uow(EfDbContext context)
        {
            Context = context;
        }

        public void Dispose() => Context.Dispose();

        public int Save() => Context.SaveChanges();

        public async Task SaveAsync() => await Context.SaveChangesAsync();

        public async Task<int> ExecuteSqlInterpolatedAsync(FormattableString sql)
            => await Context.Database.ExecuteSqlInterpolatedAsync(sql);

        public int ExecuteSqlInterpolated(FormattableString sql) => Context.Database.ExecuteSqlInterpolated(sql);

        public int ExecuteSqlRaw(string sql, params object[] parameters)
            => Context.Database.ExecuteSqlRaw(sql, parameters);

        public Task<int> ExecuteSqlRawAsync(string sql, params object[] parameters)
            => Context.Database.ExecuteSqlRawAsync(sql, parameters);


    }

}
