using app.core.EntityAndDtoStructure.DtoStructure;
using app.core.EntityAndDtoStructure.EntityStructure;
using App.core;
using App.core.Extensions;
using App.core.Filter;
using App.core.InjectionHelper;
using App.core.ResultStructure;
using App.Data.UOW;
using App.Data.UOW.Include;
using App.Data.UOW.Include.Filter;
using AutoMapper;
using System.Linq.Expressions;

namespace App.Application.GenericService.ReadService
{
    [Injection(typeof(IUow<>), typeof(Uow<>), 1)]

    // ReSharper disable once RedundantExtendsListEntry
    public class ReadService<TEntity, TShowDto> : Share.ReadService, IAutoInjection, IReadService<TEntity, TShowDto>
    where TEntity : Entity
    where TShowDto : ShowDto

    {
        private readonly IUow<TEntity> _uow;

        public ReadService(IUow<TEntity> uow, IMapper mapper) : base(mapper)
        {
            _uow = uow;
        }


        #region GetById

        #region GetEntityById

        public Result<TEntity> GetById(int id)
            => Result<TEntity>.CreateResult(_uow.Read.GetById(id));

        public async Task<Result<TEntity>> GetByIdAsync(int id)
            => await Result<TEntity>.CreateResult(_uow.Read.GetByIdAsync(id));


        #endregion

        #region GetDtoById

        public Result<TShowDto> GetDtoById(int id)
            => Result<TShowDto>.CreateResult(Mapper.Map<TShowDto>(_uow.Read.GetById(id)));

        public async Task<Result<TShowDto>> GetDtoByIdAsync(int id)
        {
            var map = Mapper.Map<TShowDto>(await _uow.Read.GetByIdAsync(id));
            return Result<TShowDto>.CreateResult(map);
        }

        #endregion

        #region GetCustomDtoById

        public Result<TMap> GetById<TMap>(int id) where TMap : ShowDto
        {
            var map = Mapper.Map<TMap>(_uow.Read.GetById(id));
            return Result<TMap>.CreateResult(map);
        }

        public async Task<Result<TMap>> GetByIdAsync<TMap>(int id) where TMap : ShowDto
        {
            var map = Mapper.Map<TMap>(await _uow.Read.GetByIdAsync(id));
            return Result<TMap>.CreateResult(map);
        }

        #endregion

        #endregion

        #region GetAll

        #region GetAllEntity

        public Result<List<TEntity>> GetAll(IFilter<TEntity>? filter)
            => Result<List<TEntity>>.CreateResult(_uow.Read.GetAll(filter));

        public async Task<Result<List<TEntity>>> GetAllAsync(IFilter<TEntity>? filter)
            => await Result<List<TEntity>>.CreateResult(_uow.Read.GetAllAsync(filter));

        #endregion

        #region GetAllDto

        public Result<List<TShowDto>> GetAllDto(IFilter<TEntity>? filter)
            => Result<List<TShowDto>>.CreateResult(_uow.Read.GetAll(filter).Map<List<TShowDto>>());

        public async Task<Result<List<TShowDto>>> GetAllDtoAsync(IFilter<TEntity>? filter)
            => Result<List<TShowDto>>.CreateResult(Mapper.Map<List<TShowDto>>(await _uow.Read.GetAllAsync(filter)));

        #endregion

        #region GetAllCustomDto

        public Result<List<TMap>> GetAll<TMap>(IFilter<TEntity>? filter) where TMap : ShowDto
        {
            var map = Mapper.Map<List<TMap>>(_uow.Read.GetAll(filter));
            return Result<List<TMap>>.CreateResult(map);
        }


        public async Task<Result<List<TMap>>> GetAllAsync<TMap>(IFilter<TEntity>? filter)
        {
            var map = Mapper.Map<List<TMap>>(await _uow.Read.GetAllAsync(filter));
            return Result<List<TMap>>.CreateResult(map);
        }

        #endregion

        #endregion

        #region FindAll

        #region FindAllEntity

        public Result<IEnumerable<TEntity>> FindAll(Expression<Func<TEntity, bool>> condition)
            => Result<IEnumerable<TEntity>>.CreateResult(_uow.Read.FindAll(condition));


        public async Task<Result<IEnumerable<TEntity>>> FindAllAsync(Expression<Func<TEntity, bool>> condition)
            => Result<IEnumerable<TEntity>>.CreateResult(await _uow.Read.FindAllAsync(condition));

        #endregion

        #region FindAllDto
        public Result<IEnumerable<TShowDto>> FindAllDto(Expression<Func<TEntity, bool>> condition)
            => Result<IEnumerable<TShowDto>>.CreateResult(Mapper.Map<IEnumerable<TShowDto>>(_uow.Read.FindAll(condition)));


        public async Task<Result<IEnumerable<TShowDto>>> FindAllDtoAsync(Expression<Func<TEntity, bool>> condition)
            => Result<IEnumerable<TShowDto>>
                .CreateResult(Mapper.Map<IEnumerable<TShowDto>>(await _uow.Read.FindAllAsync(condition)));



        #endregion

        #region FintAllCustomDto

        public Result<IEnumerable<TMap>> FindAll<TMap>(Expression<Func<TEntity, bool>> condition)
        {
            var map = Mapper.Map<IEnumerable<TMap>>(_uow.Read.FindAll(condition));
            return Result<IEnumerable<TMap>>.CreateResult(map);
        }

        public async Task<Result<IEnumerable<TMap>>> FindAllAsync<TMap>(Expression<Func<TEntity, bool>> condition)
        {
            var map = Mapper.Map<IEnumerable<TMap>>(await _uow.Read.FindAllAsync(condition));
            return Result<IEnumerable<TMap>>.CreateResult(map);
        }

        #endregion

        #endregion

        #region Find

        #region FindEntity
        public Result<TEntity> Find(Expression<Func<TEntity, bool>> condition)
            => Result<TEntity>.CreateResult(_uow.Read.Find(condition));


        public async Task<Result<TEntity>> FindAsync(Expression<Func<TEntity, bool>> condition)
            => Result<TEntity>.CreateResult(await _uow.Read.FindAsync(condition));



        #endregion

        #region FindDto

        public Result<TShowDto> FindDto(Expression<Func<TEntity, bool>> condition)
            => Result<TShowDto>.CreateResult(Mapper.Map<TShowDto>(_uow.Read.Find(condition)));


        public async Task<Result<TShowDto>> FindDtoAsync(Expression<Func<TEntity, bool>> condition)
            => Result<TShowDto>.CreateResult(Mapper.Map<TShowDto>(await _uow.Read.FindAsync(condition)));


        #endregion

        #region FindCustomDto
        public Result<TMap> Find<TMap>(Expression<Func<TEntity, bool>> condition)
       where TMap : ShowDto
        {
            var map = Mapper.Map<TMap>(_uow.Read.Find(condition));
            return Result<TMap>.CreateResult(map);
        }

        public async Task<Result<TMap>> FindAsync<TMap>(Expression<Func<TEntity, bool>> condition)
        where TMap : ShowDto
        {
            var map = Mapper.Map<TMap>(await _uow.Read.FindAsync(condition));
            return Result<TMap>.CreateResult(map);
        }


        #endregion





        #endregion


        public bool Any(Expression<Func<TEntity, bool>> condition) => _uow.Read.Any(condition);

        public Task<bool> AnyAsync(Expression<Func<TEntity, bool>> condition) => _uow.Read.AnyAsync(condition);

        public override int Count() => _uow.Read.Count();

        public override Task<int> CountAsync() => _uow.Read.CountAsync();

        public int Count(Expression<Func<TEntity, bool>> condition) => _uow.Read.Count(condition);

        public Task<int> CountAsync(Expression<Func<TEntity, bool>> condition) => _uow.Read.CountAsync(condition);

        public override Task<bool> ExistsAsync(int id) => _uow.Read.ExistsAsync(id);

        public override bool Exists(int id) => _uow.Read.Exists(id);





    }


}

namespace App.Application.GenericService.ReadService.Include
{
    [Injection(typeof(IUow<,>), typeof(Uow<,>), 1)]

    // ReSharper disable once RedundantExtendsListEntry
    public class ReadService<TEntity, TShowDto, TInclude> : Share.ReadService, IAutoInjection, IReadService<TEntity, TShowDto, TInclude>
    where TEntity : Entity
    where TShowDto : ShowDto
    where TInclude : BaseInclude<TEntity>, new()
    {
        private readonly IUow<TEntity, TInclude> _uow;


        public ReadService(IUow<TEntity, TInclude> uow, IMapper mapper) : base(mapper)
        {
            _uow = uow;

        }


        #region GetById

        #region GetEntityById

        public Result<TEntity> GetById(int id, string[]? include)
            => Result<TEntity>.CreateResult(_uow.Read.GetById(id, include));

        public async Task<Result<TEntity>> GetByIdAsync(int id, string[]? include)
            => await Result<TEntity>.CreateResult(_uow.Read.GetByIdAsync(id, include));


        #endregion

        #region GetDtoById

        public Result<TShowDto> GetDtoById(int id, string[]? include)
            => Result<TShowDto>.CreateResult(Mapper.Map<TShowDto>(_uow.Read.GetById(id, include)));

        public async Task<Result<TShowDto>> GetDtoByIdAsync(int id, string[]? include)
        {
            var map = Mapper.Map<TShowDto>(await _uow.Read.GetByIdAsync(id, include));
            return Result<TShowDto>.CreateResult(map);
        }

        #endregion

        #region GetCustomDtoById

        public Result<TMap> GetById<TMap>(int id, string[]? include) where TMap : ShowDto
        {
            var map = Mapper.Map<TMap>(_uow.Read.GetById(id, include));
            return Result<TMap>.CreateResult(map);
        }

        public async Task<Result<TMap>> GetByIdAsync<TMap>(int id, string[]? include) where TMap : ShowDto
        {
            var map = Mapper.Map<TMap>(await _uow.Read.GetByIdAsync(id, include));
            return Result<TMap>.CreateResult(map);
        }

        #endregion

        #endregion

        #region GetAll

        #region GetAllEntity

        public Result<List<TEntity>> GetAll(string[]? include, IFilter<TEntity>? filter)
            => Result<List<TEntity>>.CreateResult(_uow.Read.GetAll(include, filter));

        public async Task<Result<List<TEntity>>> GetAllAsync(string[]? include, IFilter<TEntity>? filter)
            => await Result<List<TEntity>>.CreateResult(_uow.Read.GetAllAsync(include, filter));

        #endregion

        #region GetAllDto
        //public Result<List<TShowDto>> GetAllDto()
        //    => Result<List<TShowDto>>.CreateResult(_mapper.Map<List<TShowDto>>(_uow.Read.GetAll()));

        public Result<List<TShowDto>> GetAllDto(string[]? include, IFilter<TEntity>? filter)
            => Result<List<TShowDto>>.CreateResult(_uow.Read.GetAll(include, filter).Map<List<TShowDto>>());

        public async Task<Result<List<TShowDto>>> GetAllDtoAsync(string[]? include, IFilter<TEntity>? filter)
            => Result<List<TShowDto>>.CreateResult(Mapper.Map<List<TShowDto>>(await _uow.Read.GetAllAsync(include, filter)));

        #endregion

        #region GetAllCustomDto

        public Result<List<TMap>> GetAll<TMap>(string[]? include, IFilter<TEntity>? filter) where TMap : ShowDto
        {
            var map = Mapper.Map<List<TMap>>(_uow.Read.GetAll(include, filter));
            return Result<List<TMap>>.CreateResult(map);
        }


        public async Task<Result<List<TMap>>> GetAllAsync<TMap>(string[]? include, IFilter<TEntity>? filter)
        {
            var map = Mapper.Map<List<TMap>>(await _uow.Read.GetAllAsync(include, filter));
            return Result<List<TMap>>.CreateResult(map);
        }

        #endregion

        #endregion

        #region FindAll

        #region FindAllEntity

        public Result<IEnumerable<TEntity>> FindAll(Expression<Func<TEntity, bool>> condition, string[]? include)
            => Result<IEnumerable<TEntity>>.CreateResult(_uow.Read.FindAll(condition, include));


        public async Task<Result<IEnumerable<TEntity>>> FindAllAsync(Expression<Func<TEntity, bool>> condition, string[]? include)
            => Result<IEnumerable<TEntity>>.CreateResult(await _uow.Read.FindAllAsync(condition, include));

        #endregion

        #region FindAllDto
        public Result<IEnumerable<TShowDto>> FindAllDto(Expression<Func<TEntity, bool>> condition, string[]? include)
            => Result<IEnumerable<TShowDto>>.CreateResult(Mapper.Map<IEnumerable<TShowDto>>(_uow.Read.FindAll(condition, include)));


        public async Task<Result<IEnumerable<TShowDto>>> FindAllDtoAsync(Expression<Func<TEntity, bool>> condition, string[]? include)
            => Result<IEnumerable<TShowDto>>
                .CreateResult(Mapper.Map<IEnumerable<TShowDto>>(await _uow.Read.FindAllAsync(condition, include)));



        #endregion

        #region FintAllCustomDto

        public Result<IEnumerable<TMap>> FindAll<TMap>(Expression<Func<TEntity, bool>> condition, string[]? include)
        {
            var map = Mapper.Map<IEnumerable<TMap>>(_uow.Read.FindAll(condition, include));
            return Result<IEnumerable<TMap>>.CreateResult(map);
        }

        public async Task<Result<IEnumerable<TMap>>> FindAllAsync<TMap>(Expression<Func<TEntity, bool>> condition, string[]? include)
        {
            var map = Mapper.Map<IEnumerable<TMap>>(await _uow.Read.FindAllAsync(condition, include));
            return Result<IEnumerable<TMap>>.CreateResult(map);
        }

        #endregion

        #endregion

        #region Find

        #region FindEntity
        public Result<TEntity> Find(Expression<Func<TEntity, bool>> condition, string[]? include)
            => Result<TEntity>.CreateResult(_uow.Read.Find(condition, include));


        public async Task<Result<TEntity>> FindAsync(Expression<Func<TEntity, bool>> condition, string[]? include)
            => Result<TEntity>.CreateResult(await _uow.Read.FindAsync(condition, include));



        #endregion

        #region FindDto

        public Result<TShowDto> FindDto(Expression<Func<TEntity, bool>> condition, string[]? include)
            => Result<TShowDto>.CreateResult(Mapper.Map<TShowDto>(_uow.Read.Find(condition, include)));


        public async Task<Result<TShowDto>> FindDtoAsync(Expression<Func<TEntity, bool>> condition, string[]? include)
            => Result<TShowDto>.CreateResult(Mapper.Map<TShowDto>(await _uow.Read.FindAsync(condition, include)));


        #endregion

        #region FindCustomDto
        public Result<TMap> Find<TMap>(Expression<Func<TEntity, bool>> condition, string[]? include)
       where TMap : ShowDto
        {
            var map = Mapper.Map<TMap>(_uow.Read.Find(condition, include));
            return Result<TMap>.CreateResult(map);
        }

        public async Task<Result<TMap>> FindAsync<TMap>(Expression<Func<TEntity, bool>> condition, string[]? include)
        where TMap : ShowDto
        {
            var map = Mapper.Map<TMap>(await _uow.Read.FindAsync(condition, include));
            return Result<TMap>.CreateResult(map);
        }


        #endregion





        #endregion


        public bool Any(Expression<Func<TEntity, bool>> condition, string[]? include) => _uow.Read.Any(condition, include);

        public Task<bool> AnyAsync(Expression<Func<TEntity, bool>> condition, string[]? include) => _uow.Read.AnyAsync(condition, include);

        public override int Count() => _uow.Read.Count();

        public override Task<int> CountAsync() => _uow.Read.CountAsync();

        public int Count(Expression<Func<TEntity, bool>> condition, string[]? include) => _uow.Read.Count(condition, include);

        public Task<int> CountAsync(Expression<Func<TEntity, bool>> condition, string[]? include) => _uow.Read.CountAsync(condition, include);

        public override Task<bool> ExistsAsync(int id) => _uow.Read.ExistsAsync(id);

        public override bool Exists(int id) => _uow.Read.Exists(id);





    }


}

namespace App.Application.GenericService.ReadService.Filter
{
    [Injection(typeof(Data.UOW.Filter.IUow<,>), typeof(Data.UOW.Filter.Uow<,>), 1)]

    // ReSharper disable once RedundantExtendsListEntry
    public class ReadService<TEntity, TShowDto, TFilter> : Share.ReadService, IAutoInjection, IReadService<TEntity, TShowDto, TFilter>
    where TEntity : Entity
    where TShowDto : ShowDto
    where TFilter : Filter<TEntity>, new()
    {
        private readonly Data.UOW.Filter.IUow<TEntity, TFilter> _uow;

        public ReadService(Data.UOW.Filter.IUow<TEntity, TFilter> uow, IMapper mapper) : base(mapper)
        {
            _uow = uow;
        }


        #region GetById

        #region GetEntityById

        public Result<TEntity> GetById(int id)
            => Result<TEntity>.CreateResult(_uow.Read.GetById(id));

        public async Task<Result<TEntity>> GetByIdAsync(int id)
            => await Result<TEntity>.CreateResult(_uow.Read.GetByIdAsync(id));


        #endregion

        #region GetDtoById

        public Result<TShowDto> GetDtoById(int id)
            => Result<TShowDto>.CreateResult(Mapper.Map<TShowDto>(_uow.Read.GetById(id)));

        public async Task<Result<TShowDto>> GetDtoByIdAsync(int id)
        {
            var map = Mapper.Map<TShowDto>(await _uow.Read.GetByIdAsync(id));
            return Result<TShowDto>.CreateResult(map);
        }

        #endregion

        #region GetCustomDtoById

        public Result<TMap> GetById<TMap>(int id) where TMap : ShowDto
        {
            var map = Mapper.Map<TMap>(_uow.Read.GetById(id));
            return Result<TMap>.CreateResult(map);
        }

        public async Task<Result<TMap>> GetByIdAsync<TMap>(int id) where TMap : ShowDto
        {
            var map = Mapper.Map<TMap>(await _uow.Read.GetByIdAsync(id));
            return Result<TMap>.CreateResult(map);
        }

        #endregion

        #endregion

        #region GetAll

        #region GetAllEntity

        public Result<List<TEntity>> GetAll(IFilter<TEntity>? filter)
            => Result<List<TEntity>>.CreateResult(_uow.Read.GetAll(filter));

        public async Task<Result<List<TEntity>>> GetAllAsync(IFilter<TEntity>? filter)
            => await Result<List<TEntity>>.CreateResult(_uow.Read.GetAllAsync(filter));

        #endregion

        #region GetAllDto

        public Result<List<TShowDto>> GetAllDto(IFilter<TEntity>? filter)
            => Result<List<TShowDto>>.CreateResult(_uow.Read.GetAll(filter).Map<List<TShowDto>>());

        public async Task<Result<List<TShowDto>>> GetAllDtoAsync(IFilter<TEntity>? filter)
            => Result<List<TShowDto>>.CreateResult(Mapper.Map<List<TShowDto>>(await _uow.Read.GetAllAsync(filter)));

        #endregion

        #region GetAllCustomDto

        public Result<List<TMap>> GetAll<TMap>(IFilter<TEntity>? filter) where TMap : ShowDto
        {
            var map = Mapper.Map<List<TMap>>(_uow.Read.GetAll(filter));
            return Result<List<TMap>>.CreateResult(map);
        }


        public async Task<Result<List<TMap>>> GetAllAsync<TMap>(IFilter<TEntity>? filter)
        {
            var map = Mapper.Map<List<TMap>>(await _uow.Read.GetAllAsync(filter));
            return Result<List<TMap>>.CreateResult(map);
        }

        #endregion

        #endregion

        #region FindAll

        #region FindAllEntity

        public Result<IEnumerable<TEntity>> FindAll(Expression<Func<TEntity, bool>> condition)
            => Result<IEnumerable<TEntity>>.CreateResult(_uow.Read.FindAll(condition));


        public async Task<Result<IEnumerable<TEntity>>> FindAllAsync(Expression<Func<TEntity, bool>> condition)
            => Result<IEnumerable<TEntity>>.CreateResult(await _uow.Read.FindAllAsync(condition));

        #endregion

        #region FindAllDto
        public Result<IEnumerable<TShowDto>> FindAllDto(Expression<Func<TEntity, bool>> condition)
            => Result<IEnumerable<TShowDto>>.CreateResult(Mapper.Map<IEnumerable<TShowDto>>(_uow.Read.FindAll(condition)));


        public async Task<Result<IEnumerable<TShowDto>>> FindAllDtoAsync(Expression<Func<TEntity, bool>> condition)
            => Result<IEnumerable<TShowDto>>
                .CreateResult(Mapper.Map<IEnumerable<TShowDto>>(await _uow.Read.FindAllAsync(condition)));



        #endregion

        #region FintAllCustomDto

        public Result<IEnumerable<TMap>> FindAll<TMap>(Expression<Func<TEntity, bool>> condition)
        {
            var map = Mapper.Map<IEnumerable<TMap>>(_uow.Read.FindAll(condition));
            return Result<IEnumerable<TMap>>.CreateResult(map);
        }

        public async Task<Result<IEnumerable<TMap>>> FindAllAsync<TMap>(Expression<Func<TEntity, bool>> condition)
        {
            var map = Mapper.Map<IEnumerable<TMap>>(await _uow.Read.FindAllAsync(condition));
            return Result<IEnumerable<TMap>>.CreateResult(map);
        }

        #endregion

        #endregion

        #region Find

        #region FindEntity
        public Result<TEntity> Find(Expression<Func<TEntity, bool>> condition)
            => Result<TEntity>.CreateResult(_uow.Read.Find(condition));


        public async Task<Result<TEntity>> FindAsync(Expression<Func<TEntity, bool>> condition)
            => Result<TEntity>.CreateResult(await _uow.Read.FindAsync(condition));



        #endregion

        #region FindDto

        public Result<TShowDto> FindDto(Expression<Func<TEntity, bool>> condition)
            => Result<TShowDto>.CreateResult(Mapper.Map<TShowDto>(_uow.Read.Find(condition)));


        public async Task<Result<TShowDto>> FindDtoAsync(Expression<Func<TEntity, bool>> condition)
            => Result<TShowDto>.CreateResult(Mapper.Map<TShowDto>(await _uow.Read.FindAsync(condition)));


        #endregion

        #region FindCustomDto
        public Result<TMap> Find<TMap>(Expression<Func<TEntity, bool>> condition)
       where TMap : ShowDto
        {
            var map = Mapper.Map<TMap>(_uow.Read.Find(condition));
            return Result<TMap>.CreateResult(map);
        }

        public async Task<Result<TMap>> FindAsync<TMap>(Expression<Func<TEntity, bool>> condition)
        where TMap : ShowDto
        {
            var map = Mapper.Map<TMap>(await _uow.Read.FindAsync(condition));
            return Result<TMap>.CreateResult(map);
        }


        #endregion





        #endregion


        public bool Any(Expression<Func<TEntity, bool>> condition) => _uow.Read.Any(condition);

        public Task<bool> AnyAsync(Expression<Func<TEntity, bool>> condition) => _uow.Read.AnyAsync(condition);

        public override int Count() => _uow.Read.Count();

        public override Task<int> CountAsync() => _uow.Read.CountAsync();

        public int Count(Expression<Func<TEntity, bool>> condition) => _uow.Read.Count(condition);

        public Task<int> CountAsync(Expression<Func<TEntity, bool>> condition) => _uow.Read.CountAsync(condition);

        public override Task<bool> ExistsAsync(int id) => _uow.Read.ExistsAsync(id);

        public override bool Exists(int id) => _uow.Read.Exists(id);





    }


}

namespace App.Application.GenericService.ReadService.Include.Filter
{
    [Injection(typeof(IUow<,,>), typeof(Uow<,,>), 1)]

    // ReSharper disable once RedundantExtendsListEntry
    public class ReadService<TEntity, TShowDto, TInclude, TFilter> : Share.ReadService, IAutoInjection, IReadService<TEntity, TShowDto, TInclude, TFilter>
    where TEntity : Entity
    where TShowDto : ShowDto
    where TInclude : BaseInclude<TEntity>, new()
    where TFilter : Filter<TEntity>, new()
    {
        private readonly IUow<TEntity, TInclude, TFilter> _uow;

        public ReadService(IUow<TEntity, TInclude, TFilter> uow, IMapper mapper) : base(mapper)
        {
            _uow = uow;
        }


        #region GetById

        #region GetEntityById

        public Result<TEntity> GetById(int id, string[]? include)
            => Result<TEntity>.CreateResult(_uow.Read.GetById(id, include));

        public async Task<Result<TEntity>> GetByIdAsync(int id, string[]? include)
            => await Result<TEntity>.CreateResult(_uow.Read.GetByIdAsync(id, include));


        #endregion

        #region GetDtoById

        public Result<TShowDto> GetDtoById(int id, string[]? include)
            => Result<TShowDto>.CreateResult(Mapper.Map<TShowDto>(_uow.Read.GetById(id, include)));

        public async Task<Result<TShowDto>> GetDtoByIdAsync(int id, string[]? include)
        {
            var map = Mapper.Map<TShowDto>(await _uow.Read.GetByIdAsync(id, include));
            return Result<TShowDto>.CreateResult(map);
        }

        #endregion

        #region GetCustomDtoById

        public Result<TMap> GetById<TMap>(int id, string[]? include) where TMap : ShowDto
        {
            var map = Mapper.Map<TMap>(_uow.Read.GetById(id, include));
            return Result<TMap>.CreateResult(map);
        }

        public async Task<Result<TMap>> GetByIdAsync<TMap>(int id, string[]? include) where TMap : ShowDto
        {
            var map = Mapper.Map<TMap>(await _uow.Read.GetByIdAsync(id, include));
            return Result<TMap>.CreateResult(map);
        }

        #endregion

        #endregion

        #region GetAll

        #region GetAllEntity

        public Result<List<TEntity>> GetAll(string[]? include, IFilter<TEntity>? filter)
            => Result<List<TEntity>>.CreateResult(_uow.Read.GetAll(include, filter));

        public async Task<Result<List<TEntity>>> GetAllAsync(string[]? include, IFilter<TEntity>? filter)
            => await Result<List<TEntity>>.CreateResult(_uow.Read.GetAllAsync(include, filter));

        #endregion

        #region GetAllDto

        public Result<List<TShowDto>> GetAllDto(string[]? include, IFilter<TEntity>? filter)
            => Result<List<TShowDto>>.CreateResult(_uow.Read.GetAll(include, filter).Map<List<TShowDto>>());

        public async Task<Result<List<TShowDto>>> GetAllDtoAsync(string[]? include, IFilter<TEntity>? filter)
            => Result<List<TShowDto>>.CreateResult(Mapper.Map<List<TShowDto>>(await _uow.Read.GetAllAsync(include, filter)));

        #endregion

        #region GetAllCustomDto

        public Result<List<TMap>> GetAll<TMap>(string[]? include, IFilter<TEntity>? filter) where TMap : ShowDto
        {
            var map = Mapper.Map<List<TMap>>(_uow.Read.GetAll(include, filter));
            return Result<List<TMap>>.CreateResult(map);
        }


        public async Task<Result<List<TMap>>> GetAllAsync<TMap>(string[]? include, IFilter<TEntity>? filter)
        {
            var map = Mapper.Map<List<TMap>>(await _uow.Read.GetAllAsync(include, filter));
            return Result<List<TMap>>.CreateResult(map);
        }

        #endregion

        #endregion

        #region FindAll

        #region FindAllEntity

        public Result<IEnumerable<TEntity>> FindAll(Expression<Func<TEntity, bool>> condition, string[]? include)
            => Result<IEnumerable<TEntity>>.CreateResult(_uow.Read.FindAll(condition, include));


        public async Task<Result<IEnumerable<TEntity>>> FindAllAsync(Expression<Func<TEntity, bool>> condition, string[]? include)
            => Result<IEnumerable<TEntity>>.CreateResult(await _uow.Read.FindAllAsync(condition, include));

        #endregion

        #region FindAllDto
        public Result<IEnumerable<TShowDto>> FindAllDto(Expression<Func<TEntity, bool>> condition, string[]? include)
            => Result<IEnumerable<TShowDto>>.CreateResult(Mapper.Map<IEnumerable<TShowDto>>(_uow.Read.FindAll(condition, include)));


        public async Task<Result<IEnumerable<TShowDto>>> FindAllDtoAsync(Expression<Func<TEntity, bool>> condition, string[]? include)
            => Result<IEnumerable<TShowDto>>
                .CreateResult(Mapper.Map<IEnumerable<TShowDto>>(await _uow.Read.FindAllAsync(condition, include)));



        #endregion

        #region FintAllCustomDto

        public Result<IEnumerable<TMap>> FindAll<TMap>(Expression<Func<TEntity, bool>> condition, string[]? include)
        {
            var map = Mapper.Map<IEnumerable<TMap>>(_uow.Read.FindAll(condition, include));
            return Result<IEnumerable<TMap>>.CreateResult(map);
        }

        public async Task<Result<IEnumerable<TMap>>> FindAllAsync<TMap>(Expression<Func<TEntity, bool>> condition, string[]? include)
        {
            var map = Mapper.Map<IEnumerable<TMap>>(await _uow.Read.FindAllAsync(condition, include));
            return Result<IEnumerable<TMap>>.CreateResult(map);
        }

        #endregion

        #endregion

        #region Find

        #region FindEntity
        public Result<TEntity> Find(Expression<Func<TEntity, bool>> condition, string[]? include)
            => Result<TEntity>.CreateResult(_uow.Read.Find(condition, include));


        public async Task<Result<TEntity>> FindAsync(Expression<Func<TEntity, bool>> condition, string[]? include)
            => Result<TEntity>.CreateResult(await _uow.Read.FindAsync(condition, include));



        #endregion

        #region FindDto

        public Result<TShowDto> FindDto(Expression<Func<TEntity, bool>> condition, string[]? include)
            => Result<TShowDto>.CreateResult(Mapper.Map<TShowDto>(_uow.Read.Find(condition, include)));


        public async Task<Result<TShowDto>> FindDtoAsync(Expression<Func<TEntity, bool>> condition, string[]? include)
            => Result<TShowDto>.CreateResult(Mapper.Map<TShowDto>(await _uow.Read.FindAsync(condition, include)));


        #endregion

        #region FindCustomDto
        public Result<TMap> Find<TMap>(Expression<Func<TEntity, bool>> condition, string[]? include)
       where TMap : ShowDto
        {
            var map = Mapper.Map<TMap>(_uow.Read.Find(condition, include));
            return Result<TMap>.CreateResult(map);
        }

        public async Task<Result<TMap>> FindAsync<TMap>(Expression<Func<TEntity, bool>> condition, string[]? include)
        where TMap : ShowDto
        {
            var map = Mapper.Map<TMap>(await _uow.Read.FindAsync(condition, include));
            return Result<TMap>.CreateResult(map);
        }


        #endregion





        #endregion


        public bool Any(Expression<Func<TEntity, bool>> condition, string[]? include) => _uow.Read.Any(condition, include);

        public Task<bool> AnyAsync(Expression<Func<TEntity, bool>> condition, string[]? include) => _uow.Read.AnyAsync(condition, include);

        public override int Count() => _uow.Read.Count();

        public override Task<int> CountAsync() => _uow.Read.CountAsync();

        public int Count(Expression<Func<TEntity, bool>> condition, string[]? include) => _uow.Read.Count(condition, include);

        public Task<int> CountAsync(Expression<Func<TEntity, bool>> condition, string[]? include) => _uow.Read.CountAsync(condition, include);

        public override Task<bool> ExistsAsync(int id) => _uow.Read.ExistsAsync(id);

        public override bool Exists(int id) => _uow.Read.Exists(id);





    }


}

namespace App.Application.GenericService.ReadService.Share
{

    public abstract class ReadService : IReadService

    {
        protected readonly IMapper Mapper;

        protected ReadService(IMapper mapper)
        {
            Mapper = mapper;
        }


        public abstract int Count();


        public abstract Task<int> CountAsync();


        public abstract bool Exists(int id);


        public abstract Task<bool> ExistsAsync(int id);
    }


}






























//using app.core;
//using app.core.EntityAndDtoStructure.DtoStructure;
//using app.core.EntityAndDtoStructure.EntityStructure;
//using App.core;
//using App.core.Extensions;
//using App.Data.UOW;
//using AutoMapper;
//using System.Linq.Expressions;

//namespace App.Application.GenericService.ReadService;

//[Injection(typeof(IUow<,>), typeof(Uow<,>), 1)]

//// ReSharper disable once RedundantExtendsListEntry
//public class ReadService<TEntity, TShowDto, TInclude> : IAutoInjection, IReadService<TEntity, TShowDto, TInclude>
//    where TEntity : Entity
//    where TShowDto : ShowDto
//    where TInclude : BaseInclude<TEntity>, new()
//{
//    private readonly IUow<TEntity, TInclude> _uow;
//    private readonly IMapper _mapper;

//    public ReadService(IUow<TEntity, TInclude> uow, IMapper mapper)
//    {
//        _uow = uow;
//        _mapper = mapper;
//    }


//    #region GetById

//    #region GetEntityById

//    public Result<TEntity> GetById(int id)
//        => Result<TEntity>.CreateResult(_uow.Read.GetById(id));

//    public async Task<Result<TEntity>> GetByIdAsync(int id)
//        => await Result<TEntity>.CreateResult(_uow.Read.GetByIdAsync(id)!);


//    #endregion

//    #region GetDtoById

//    public Result<TShowDto> GetDtoById(int id)
//        => Result<TShowDto>.CreateResult(_mapper.Map<TShowDto>(_uow.Read.GetById(id)));

//    public async Task<Result<TShowDto>> GetDtoByIdAsync(int id)
//    {
//        var map = _mapper.Map<TShowDto>(await _uow.Read.GetByIdAsync(id));
//        return Result<TShowDto>.CreateResult(map);
//    }

//    #endregion

//    #region GetCustomDtoById

//    public Result<TMap> GetById<TMap>(int id) where TMap : ShowDto
//    {
//        var map = _mapper.Map<TMap>(_uow.Read.GetById(id));
//        return Result<TMap>.CreateResult(map);
//    }

//    public async Task<Result<TMap>> GetByIdAsync<TMap>(int id) where TMap : ShowDto
//    {
//        var map = _mapper.Map<TMap>(await _uow.Read.GetByIdAsync(id));
//        return Result<TMap>.CreateResult(map);
//    }

//    #endregion

//    #endregion

//    #region GetAll

//    #region GetAllEntity

//    public Result<List<TEntity>> GetAll()
//        => Result<List<TEntity>>.CreateResult(_uow.Read.GetAll());

//    public async Task<Result<List<TEntity>>> GetAllAsync()
//        => await Result<List<TEntity>>.CreateResult(_uow.Read.GetAllAsync());

//    #endregion

//    #region GetAllDto
//    //public Result<List<TShowDto>> GetAllDto()
//    //    => Result<List<TShowDto>>.CreateResult(_mapper.Map<List<TShowDto>>(_uow.Read.GetAll()));

//    public Result<List<TShowDto>> GetAllDto()
//        => Result<List<TShowDto>>.CreateResult(_uow.Read.GetAll().Map<List<TShowDto>>());

//    public async Task<Result<List<TShowDto>>> GetAllDtoAsync()
//        => Result<List<TShowDto>>.CreateResult(_mapper.Map<List<TShowDto>>(await _uow.Read.GetAllAsync()));

//    #endregion

//    #region GetAllCustomDto

//    public Result<List<TMap>> GetAll<TMap>() where TMap : ShowDto
//    {
//        var map = _mapper.Map<List<TMap>>(_uow.Read.GetAll());
//        return Result<List<TMap>>.CreateResult(map);
//    }


//    public async Task<Result<List<TMap>>> GetAllAsync<TMap>()
//    {
//        var map = _mapper.Map<List<TMap>>(await _uow.Read.GetAllAsync());
//        return Result<List<TMap>>.CreateResult(map);
//    }

//    #endregion

//    #endregion

//    #region FindAll

//    #region FindAllEntity

//    public Result<IEnumerable<TEntity>> FindAll(Expression<Func<TEntity, bool>> condition)
//        => Result<IEnumerable<TEntity>>.CreateResult(_uow.Read.FindAll(condition));


//    public async Task<Result<IEnumerable<TEntity>>> FindAllAsync(Expression<Func<TEntity, bool>> condition)
//        => Result<IEnumerable<TEntity>>.CreateResult(await _uow.Read.FindAllAsync(condition));

//    #endregion

//    #region FindAllDto
//    public Result<IEnumerable<TShowDto>> FindAllDto(Expression<Func<TEntity, bool>> condition)
//        => Result<IEnumerable<TShowDto>>.CreateResult(_mapper.Map<IEnumerable<TShowDto>>(_uow.Read.FindAll(condition)));


//    public async Task<Result<IEnumerable<TShowDto>>> FindAllDtoAsync(Expression<Func<TEntity, bool>> condition)
//        => Result<IEnumerable<TShowDto>>
//            .CreateResult(_mapper.Map<IEnumerable<TShowDto>>(await _uow.Read.FindAllAsync(condition)));



//    #endregion

//    #region FintAllCustomDto

//    public Result<IEnumerable<TMap>> FindAll<TMap>(Expression<Func<TEntity, bool>> condition)
//    {
//        var map = _mapper.Map<IEnumerable<TMap>>(_uow.Read.FindAll(condition));
//        return Result<IEnumerable<TMap>>.CreateResult(map);
//    }

//    public async Task<Result<IEnumerable<TMap>>> FindAllAsync<TMap>(Expression<Func<TEntity, bool>> condition)
//    {
//        var map = _mapper.Map<IEnumerable<TMap>>(await _uow.Read.FindAllAsync(condition));
//        return Result<IEnumerable<TMap>>.CreateResult(map);
//    }

//    #endregion

//    #endregion

//    #region Find

//    #region FindEntity
//    public Result<TEntity> Find(Expression<Func<TEntity, bool>> condition)
//        => Result<TEntity>.CreateResult(_uow.Read.Find(condition)!);


//    public async Task<Result<TEntity>> FindAsync(Expression<Func<TEntity, bool>> condition)
//        => Result<TEntity>.CreateResult(await _uow.Read.FindAsync(condition));



//    #endregion

//    #region FindDto

//    public Result<TShowDto> FindDto(Expression<Func<TEntity, bool>> condition)
//        => Result<TShowDto>.CreateResult(_mapper.Map<TShowDto>(_uow.Read.Find(condition)));


//    public async Task<Result<TShowDto>> FindDtoAsync(Expression<Func<TEntity, bool>> condition)
//        => Result<TShowDto>.CreateResult(_mapper.Map<TShowDto>(await _uow.Read.FindAsync(condition)));


//    #endregion

//    #region FindCustomDto
//    public Result<TMap> Find<TMap>(Expression<Func<TEntity, bool>> condition)
//   where TMap : ShowDto
//    {
//        var map = _mapper.Map<TMap>(_uow.Read.Find(condition));
//        return Result<TMap>.CreateResult(map);
//    }

//    public async Task<Result<TMap>> FindAsync<TMap>(Expression<Func<TEntity, bool>> condition)
//    where TMap : ShowDto
//    {
//        var map = _mapper.Map<TMap>(await _uow.Read.FindAsync(condition));
//        return Result<TMap>.CreateResult(map);
//    }


//    #endregion





//    #endregion


//    public bool Any(Expression<Func<TEntity, bool>> condition) => _uow.Read.Any(condition);

//    public Task<bool> AnyAsync(Expression<Func<TEntity, bool>> condition) => _uow.Read.AnyAsync(condition);

//    public int Count() => _uow.Read.Count();

//    public Task<int> CountAsync() => _uow.Read.CountAsync();

//    public int Count(Expression<Func<TEntity, bool>> condition) => _uow.Read.Count(condition);

//    public Task<int> CountAsync(Expression<Func<TEntity, bool>> condition) => _uow.Read.CountAsync(condition);

//    public Task<bool> ExistsAsync(int id) => _uow.Read.ExistsAsync(id);

//    public bool Exists(int id) => _uow.Read.Exists(id);




//    public TEntity GetCustomerById(int id, string[]? include)
//    {
//        return _uow.Read.GetCustomerById(id, include);
//    }
//}
