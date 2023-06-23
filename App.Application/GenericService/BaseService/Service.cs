using app.core.EntityAndDtoStructure.DtoStructure;
using app.core.EntityAndDtoStructure.EntityStructure;
using App.Application.GenericService.BaseService.Share;
using App.Application.GenericService.ReadService;
using App.Application.GenericService.ReadService.Include;
using App.Application.GenericService.ReadService.Include.Filter;
using App.Application.GenericService.WriteService;
using App.Application.GenericService.WriteService.Include;
using App.Application.GenericService.WriteService.Include.Filter;
using App.core;
using App.core.Filter;
using App.core.InjectionHelper;
using App.Data.UOW;
using App.Data.UOW.Include;
using App.Data.UOW.Include.Filter;
using AutoMapper;
using FluentValidation;

namespace App.Application.GenericService.BaseService
{
    [Injection(typeof(IUow<>), typeof(Uow<>), 1)]
    public class Service<TEntity, TCreateDto, TShowDto>
        // ReSharper disable once RedundantExtendsListEntry
        : Service<TEntity>, IAutoInjection, IService<TEntity, TCreateDto, TShowDto>
        where TEntity : Entity
        where TCreateDto : CreateDto
        where TShowDto : ShowDto


    {
        private readonly IUow<TEntity> _uow;
        public WriteService<TEntity, TCreateDto, TShowDto> Write { get; set; }
        public ReadService<TEntity, TShowDto> Read { get; set; }
        public Service(IUow<TEntity> uow, IMapper mapper, IValidator<TCreateDto> validator)
        {
            _uow = uow;
            Read = new ReadService<TEntity, TShowDto>(uow, mapper);
            Write = new WriteService<TEntity, TCreateDto, TShowDto>(uow, mapper, validator);
        }

        public override Task<int> ExecuteSqlInterpolatedAsync(FormattableString sql) => _uow.ExecuteSqlInterpolatedAsync(sql);

        public override int ExecuteSqlInterpolated(FormattableString sql) => _uow.ExecuteSqlInterpolated(sql);

        public override int ExecuteSqlRaw(string sql, params object[] parameters) => _uow.ExecuteSqlRaw(sql, parameters);

        public override Task<int> ExecuteSqlRawAsync(string sql, params object[] parameters) => _uow.ExecuteSqlRawAsync(sql, parameters);

    }
}

namespace App.Application.GenericService.BaseService.Include
{
    [Injection(typeof(IUow<,>), typeof(Uow<,>), 1)]
    public class Service<TEntity, TCreateDto, TShowDto, TInclude>
        // ReSharper disable once RedundantExtendsListEntry
        : Service<TEntity>, IAutoInjection, IService<TEntity, TCreateDto, TShowDto, TInclude>
        where TEntity : Entity
        where TCreateDto : CreateDto
        where TShowDto : ShowDto
        where TInclude : BaseInclude<TEntity>, new()

    {
        private readonly IUow<TEntity, TInclude> _uow;
        public WriteService<TEntity, TCreateDto, TShowDto, TInclude> Write { get; set; }
        public ReadService<TEntity, TShowDto, TInclude> Read { get; set; }
        public Service(IUow<TEntity, TInclude> uow, IMapper mapper, IValidator<TCreateDto> validator)
        {
            _uow = uow;
            Read = new ReadService<TEntity, TShowDto, TInclude>(uow, mapper);
            Write = new WriteService<TEntity, TCreateDto, TShowDto, TInclude>(uow, mapper, validator);
        }

        public override Task<int> ExecuteSqlInterpolatedAsync(FormattableString sql) => _uow.ExecuteSqlInterpolatedAsync(sql);

        public override int ExecuteSqlInterpolated(FormattableString sql) => _uow.ExecuteSqlInterpolated(sql);

        public override int ExecuteSqlRaw(string sql, params object[] parameters) => _uow.ExecuteSqlRaw(sql, parameters);

        public override Task<int> ExecuteSqlRawAsync(string sql, params object[] parameters) => _uow.ExecuteSqlRawAsync(sql, parameters);

    }
}

namespace App.Application.GenericService.BaseService.Filter
{
    [Injection(typeof(Data.UOW.Filter.IUow<,>), typeof(Data.UOW.Filter.Uow<,>), 1)]
    public class Service<TEntity, TCreateDto, TShowDto, TFilter>
        // ReSharper disable once RedundantExtendsListEntry
        : Service<TEntity>, IAutoInjection, IService<TEntity, TCreateDto, TShowDto, TFilter>
        where TEntity : Entity
        where TCreateDto : CreateDto
        where TShowDto : ShowDto
        where TFilter : Filter<TEntity>, new()

    {
        private readonly Data.UOW.Filter.IUow<TEntity, TFilter> _uow;
        public WriteService.Filter.WriteService<TEntity, TCreateDto, TShowDto, TFilter> Write { get; set; }
        public ReadService.Filter.ReadService<TEntity, TShowDto, TFilter> Read { get; set; }
        public Service(Data.UOW.Filter.IUow<TEntity, TFilter> uow, IMapper mapper, IValidator<TCreateDto> validator)
        {
            _uow = uow;
            Read = new ReadService.Filter.ReadService<TEntity, TShowDto, TFilter>(uow, mapper);
            Write = new WriteService.Filter.WriteService<TEntity, TCreateDto, TShowDto, TFilter>(uow, mapper, validator);
        }

        public override Task<int> ExecuteSqlInterpolatedAsync(FormattableString sql) => _uow.ExecuteSqlInterpolatedAsync(sql);

        public override int ExecuteSqlInterpolated(FormattableString sql) => _uow.ExecuteSqlInterpolated(sql);

        public override int ExecuteSqlRaw(string sql, params object[] parameters) => _uow.ExecuteSqlRaw(sql, parameters);

        public override Task<int> ExecuteSqlRawAsync(string sql, params object[] parameters) => _uow.ExecuteSqlRawAsync(sql, parameters);

    }
}

namespace App.Application.GenericService.BaseService.Include.Filter
{
    [Injection(typeof(IUow<,,>), typeof(Uow<,,>), 1)]
    public class Service<TEntity, TCreateDto, TShowDto, TInclude, TFilter>
        // ReSharper disable once RedundantExtendsListEntry
        : Service<TEntity>, IAutoInjection, IService<TEntity, TCreateDto, TShowDto, TInclude, TFilter>
        where TEntity : Entity
        where TCreateDto : CreateDto
        where TShowDto : ShowDto
        where TInclude : BaseInclude<TEntity>, new()
        where TFilter : Filter<TEntity>, new()

    {
        private readonly IUow<TEntity, TInclude, TFilter> _uow;
        public WriteService<TEntity, TCreateDto, TShowDto, TInclude, TFilter> Write { get; set; }
        public ReadService<TEntity, TShowDto, TInclude, TFilter> Read { get; set; }
        public Service(IUow<TEntity, TInclude, TFilter> uow, IMapper mapper, IValidator<TCreateDto> validator)
        {
            _uow = uow;
            Read = new ReadService<TEntity, TShowDto, TInclude, TFilter>(uow, mapper);
            Write = new WriteService<TEntity, TCreateDto, TShowDto, TInclude, TFilter>(uow, mapper, validator);
        }

        public override Task<int> ExecuteSqlInterpolatedAsync(FormattableString sql) => _uow.ExecuteSqlInterpolatedAsync(sql);

        public override int ExecuteSqlInterpolated(FormattableString sql) => _uow.ExecuteSqlInterpolated(sql);

        public override int ExecuteSqlRaw(string sql, params object[] parameters) => _uow.ExecuteSqlRaw(sql, parameters);

        public override Task<int> ExecuteSqlRawAsync(string sql, params object[] parameters) => _uow.ExecuteSqlRawAsync(sql, parameters);

    }
}

namespace App.Application.GenericService.BaseService.Share
{
    public abstract class Service<TEntity>
        : IService<TEntity>
        where TEntity : Entity

    {
        public abstract Task<int> ExecuteSqlInterpolatedAsync(FormattableString sql);


        public abstract int ExecuteSqlInterpolated(FormattableString sql);

        public abstract int ExecuteSqlRaw(string sql, params object[] parameters);


        public abstract Task<int> ExecuteSqlRawAsync(string sql, params object[] parameters);

    }
}

