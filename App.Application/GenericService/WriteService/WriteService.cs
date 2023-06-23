using app.core.EntityAndDtoStructure.DtoStructure;
using app.core.EntityAndDtoStructure.EntityStructure;
using App.core;
using App.core.Filter;
using App.core.InjectionHelper;
using App.core.ResultStructure;
using App.core.ValidatorHelper;
using App.Data.UOW;
using App.Data.UOW.Include;
using App.Data.UOW.Include.Filter;
using AutoMapper;
using FluentValidation;

namespace App.Application.GenericService.WriteService
{
    [Injection(typeof(IUow<>), typeof(Uow<>), 1)]
    public class WriteService<TEntity, TCreateDto, TShowDto> : Share.WriteService<TEntity, TCreateDto>,
    IWriteService<TEntity, TCreateDto, TShowDto>, IAutoInjection
    where TEntity : Entity
    where TCreateDto : CreateDto
    where TShowDto : ShowDto

    {
        private readonly IUow<TEntity> _uow;


        public WriteService(IUow<TEntity> uow, IMapper mapper, IValidator<TCreateDto> validator) : base(mapper, validator)
        {
            _uow = uow;
        }


        public Result<TShowDto> Create(TCreateDto createDto)
        {
            var validatorError = ValidateResult.Errors(createDto, out var isValid);


            var entity = isValid ? _uow.Write.SaveAdd(_mapper.Map<TEntity>(createDto)) : default!;


            return Result<TShowDto>.CreateResult
                (validatorError, entity, _mapper.Map<TShowDto>(entity), Message.CreateError);

        }

        public Result<TShowDto> Create<TDto>(TDto createDto)
        {
            var validatorError = ValidateResult.Errors(createDto, out var isValid);


            var entity = isValid ? _uow.Write.Add(_mapper.Map<TEntity>(createDto)) : default!;
            _uow.Save();

            return Result<TShowDto>.CreateResult
                (validatorError, entity, _mapper.Map<TShowDto>(entity), Message.CreateError);

        }





        public async Task<Result<TShowDto>> CreateAsync(TCreateDto createDto)
        {
            TEntity entity = default!;
            var validatorError =
                ValidateResult.GetValidationResult(createDto, out var isValid);


            entity = isValid ? await _uow.Write.AddAsync(_mapper.Map<TEntity>(createDto)) : default!;
            await _uow.SaveAsync();

            return Result<TShowDto>.CreateResult
                        (validatorError, entity, _mapper.Map<TShowDto>(entity), Message.CreateError);

        }


        public List<Result<TShowDto>> AddRange(IEnumerable<TCreateDto> dtos)
        {
            dtos = dtos.ToList();
            var validatorErrors = new List<List<ValidatorError>>();
            var isValid = true;
            List<TEntity> entities = default!;
            foreach (var dto in dtos)
            {
                validatorErrors.Add(ValidateResult.GetValidationResult(dto, out var _isValid));
                isValid = isValid && _isValid;
            }

            entities = isValid ? _uow.Write.AddRange(_mapper.Map<IEnumerable<TEntity>>(dtos)) : default!;
            _uow.Save();

            var results = dtos
                .Select((_, index) => Result<TShowDto>.CreateResult(
                        validatorErrors[index],
                        entities[index],
                        _mapper.Map<TShowDto>(entities[index]),
                        Message.CreateError
                    )).ToList();

            return results;

        }

        public void AddRangeAsync(IEnumerable<TEntity> entities)
        {
            _uow.Write.AddRangeAsync(entities);
            _uow.SaveAsync();
        }

        //todo: what if the entity is not found?
        public void Delete(TEntity entity)
        {
            _uow.Write.Remove(entity);
            _uow.Save();
        }

        //todo: what if the entity is not found?
        public TEntity DeleteById(int id)
        {
            var entity = _uow.Write.RemoveById(id);
            _uow.Save();
            return entity;
        }




        public void RemoveRange(IEnumerable<TEntity> entities)
        {
            _uow.Write.RemoveRange(entities);
            _uow.Save();
        }

        public void Update(TEntity entity)
        {
            _uow.Write.Update(entity);
            _uow.Save();
        }

        public void UpdateRange(IEnumerable<TEntity> entities)
        {
            _uow.Write.UpdateRange(entities);
            _uow.Save();
        }

        public IEnumerable<TEntity> FromSqlInterpolated(FormattableString sql)
        {
            return _uow.Write.FromSqlInterpolated(sql);
        }
    }
}

namespace App.Application.GenericService.WriteService.Include
{
    [Injection(typeof(IUow<,>), typeof(Uow<,>), 1)]
    public class WriteService<TEntity, TCreateDto, TShowDto, TInclude> : Share.WriteService<TEntity, TCreateDto>,
    IWriteService<TEntity, TCreateDto, TShowDto, TInclude>, IAutoInjection
    where TEntity : Entity
    where TCreateDto : CreateDto
    where TShowDto : ShowDto
    where TInclude : BaseInclude<TEntity>, new()
    {
        private readonly IUow<TEntity, TInclude> _uow;


        public WriteService(IUow<TEntity, TInclude> uow, IMapper mapper, IValidator<TCreateDto> validator) : base(mapper, validator)
        {
            _uow = uow;
        }


        public Result<TShowDto> Create(TCreateDto createDto)
        {
            var validatorError = ValidateResult.Errors(createDto, out var isValid);


            var entity = isValid ? _uow.Write.SaveAdd(_mapper.Map<TEntity>(createDto)) : default!;


            return Result<TShowDto>.CreateResult
                (validatorError, entity, _mapper.Map<TShowDto>(entity), Message.CreateError);

        }

        public Result<TShowDto> Create<TDto>(TDto createDto)
        {
            var validatorError = ValidateResult.Errors(createDto, out var isValid);


            var entity = isValid ? _uow.Write.Add(_mapper.Map<TEntity>(createDto)) : default!;
            _uow.Save();

            return Result<TShowDto>.CreateResult
                (validatorError, entity, _mapper.Map<TShowDto>(entity), Message.CreateError);

        }





        public async Task<Result<TShowDto>> CreateAsync(TCreateDto createDto)
        {
            TEntity entity = default!;
            var validatorError =
                ValidateResult.GetValidationResult(createDto, out var isValid);


            entity = isValid ? await _uow.Write.AddAsync(_mapper.Map<TEntity>(createDto)) : default!;
            await _uow.SaveAsync();

            return Result<TShowDto>.CreateResult
                        (validatorError, entity, _mapper.Map<TShowDto>(entity), Message.CreateError);

        }


        public List<Result<TShowDto>> AddRange(IEnumerable<TCreateDto> dtos)
        {
            dtos = dtos.ToList();
            var validatorErrors = new List<List<ValidatorError>>();
            var isValid = true;
            List<TEntity> entities = default!;
            foreach (var dto in dtos)
            {
                validatorErrors.Add(ValidateResult.GetValidationResult(dto, out var _isValid));
                isValid = isValid && _isValid;
            }

            entities = isValid ? _uow.Write.AddRange(_mapper.Map<IEnumerable<TEntity>>(dtos)) : default!;
            _uow.Save();

            var results = dtos
                .Select((_, index) => Result<TShowDto>.CreateResult(
                        validatorErrors[index],
                        entities[index],
                        _mapper.Map<TShowDto>(entities[index]),
                        Message.CreateError
                    )).ToList();

            return results;

        }

        public void AddRangeAsync(IEnumerable<TEntity> entities)
        {
            _uow.Write.AddRangeAsync(entities);
            _uow.SaveAsync();
        }

        //todo: what if the entity is not found?
        public void Delete(TEntity entity)
        {
            _uow.Write.Remove(entity);
            _uow.Save();
        }

        //todo: what if the entity is not found?
        public TEntity DeleteById(int id)
        {
            var entity = _uow.Write.RemoveById(id);
            _uow.Save();
            return entity;
        }




        public void RemoveRange(IEnumerable<TEntity> entities)
        {
            _uow.Write.RemoveRange(entities);
            _uow.Save();
        }

        public void Update(TEntity entity)
        {
            _uow.Write.Update(entity);
            _uow.Save();
        }

        public void UpdateRange(IEnumerable<TEntity> entities)
        {
            _uow.Write.UpdateRange(entities);
            _uow.Save();
        }

        public IEnumerable<TEntity> FromSqlInterpolated(FormattableString sql)
        {
            return _uow.Write.FromSqlInterpolated(sql);
        }
    }
}

namespace App.Application.GenericService.WriteService.Filter
{
    [Injection(typeof(IUow<,>), typeof(Uow<,>), 1)]
    public class WriteService<TEntity, TCreateDto, TShowDto, TFilter> : Share.WriteService<TEntity, TCreateDto>,
    IWriteService<TEntity, TCreateDto, TShowDto, TFilter>, IAutoInjection
    where TEntity : Entity
    where TCreateDto : CreateDto
    where TShowDto : ShowDto
    where TFilter : Filter<TEntity>, new()
    {
        private readonly Data.UOW.Filter.IUow<TEntity, TFilter> _uow;


        public WriteService(Data.UOW.Filter.IUow<TEntity, TFilter> uow, IMapper mapper, IValidator<TCreateDto> validator) : base(mapper, validator)
        {
            _uow = uow;
        }


        public Result<TShowDto> Create(TCreateDto createDto)
        {
            var validatorError = ValidateResult.Errors(createDto, out var isValid);


            var entity = isValid ? _uow.Write.SaveAdd(_mapper.Map<TEntity>(createDto)) : default!;


            return Result<TShowDto>.CreateResult
                (validatorError, entity, _mapper.Map<TShowDto>(entity), Message.CreateError);

        }

        public Result<TShowDto> Create<TDto>(TDto createDto)
        {
            var validatorError = ValidateResult.Errors(createDto, out var isValid);


            var entity = isValid ? _uow.Write.Add(_mapper.Map<TEntity>(createDto)) : default!;
            _uow.Save();

            return Result<TShowDto>.CreateResult
                (validatorError, entity, _mapper.Map<TShowDto>(entity), Message.CreateError);

        }





        public async Task<Result<TShowDto>> CreateAsync(TCreateDto createDto)
        {
            TEntity entity = default!;
            var validatorError =
                ValidateResult.GetValidationResult(createDto, out var isValid);


            entity = isValid ? await _uow.Write.AddAsync(_mapper.Map<TEntity>(createDto)) : default!;
            await _uow.SaveAsync();

            return Result<TShowDto>.CreateResult
                        (validatorError, entity, _mapper.Map<TShowDto>(entity), Message.CreateError);

        }


        public List<Result<TShowDto>> AddRange(IEnumerable<TCreateDto> dtos)
        {
            dtos = dtos.ToList();
            var validatorErrors = new List<List<ValidatorError>>();
            var isValid = true;
            List<TEntity> entities = default!;
            foreach (var dto in dtos)
            {
                validatorErrors.Add(ValidateResult.GetValidationResult(dto, out var _isValid));
                isValid = isValid && _isValid;
            }

            entities = isValid ? _uow.Write.AddRange(_mapper.Map<IEnumerable<TEntity>>(dtos)) : default!;
            _uow.Save();

            var results = dtos
                .Select((_, index) => Result<TShowDto>.CreateResult(
                        validatorErrors[index],
                        entities[index],
                        _mapper.Map<TShowDto>(entities[index]),
                        Message.CreateError
                    )).ToList();

            return results;

        }

        public void AddRangeAsync(IEnumerable<TEntity> entities)
        {
            _uow.Write.AddRangeAsync(entities);
            _uow.SaveAsync();
        }

        //todo: what if the entity is not found?
        public void Delete(TEntity entity)
        {
            _uow.Write.Remove(entity);
            _uow.Save();
        }

        //todo: what if the entity is not found?
        public TEntity DeleteById(int id)
        {
            var entity = _uow.Write.RemoveById(id);
            _uow.Save();
            return entity;
        }




        public void RemoveRange(IEnumerable<TEntity> entities)
        {
            _uow.Write.RemoveRange(entities);
            _uow.Save();
        }

        public void Update(TEntity entity)
        {
            _uow.Write.Update(entity);
            _uow.Save();
        }

        public void UpdateRange(IEnumerable<TEntity> entities)
        {
            _uow.Write.UpdateRange(entities);
            _uow.Save();
        }

        public IEnumerable<TEntity> FromSqlInterpolated(FormattableString sql)
        {
            return _uow.Write.FromSqlInterpolated(sql);
        }
    }
}

namespace App.Application.GenericService.WriteService.Include.Filter
{
    [Injection(typeof(IUow<,,>), typeof(Uow<,,>), 1)]
    public class WriteService<TEntity, TCreateDto, TShowDto, TInclude, TFilter> : Share.WriteService<TEntity, TCreateDto>,
    IWriteService<TEntity, TCreateDto, TShowDto, TInclude, TFilter>, IAutoInjection
    where TEntity : Entity
    where TCreateDto : CreateDto
    where TShowDto : ShowDto
    where TInclude : BaseInclude<TEntity>, new()
    where TFilter : Filter<TEntity>, new()
    {
        private readonly IUow<TEntity, TInclude, TFilter> _uow;


        public WriteService(IUow<TEntity, TInclude, TFilter> uow, IMapper mapper, IValidator<TCreateDto> validator) : base(mapper, validator)
        {
            _uow = uow;
        }


        public Result<TShowDto> Create(TCreateDto createDto)
        {
            var validatorError = ValidateResult.Errors(createDto, out var isValid);


            var entity = isValid ? _uow.Write.SaveAdd(_mapper.Map<TEntity>(createDto)) : default!;


            return Result<TShowDto>.CreateResult
                (validatorError, entity, _mapper.Map<TShowDto>(entity), Message.CreateError);

        }

        public Result<TShowDto> Create<TDto>(TDto createDto)
        {
            var validatorError = ValidateResult.Errors(createDto, out var isValid);


            var entity = isValid ? _uow.Write.Add(_mapper.Map<TEntity>(createDto)) : default!;
            _uow.Save();

            return Result<TShowDto>.CreateResult
                (validatorError, entity, _mapper.Map<TShowDto>(entity), Message.CreateError);

        }





        public async Task<Result<TShowDto>> CreateAsync(TCreateDto createDto)
        {
            TEntity entity = default!;
            var validatorError =
                ValidateResult.GetValidationResult(createDto, out var isValid);


            entity = isValid ? await _uow.Write.AddAsync(_mapper.Map<TEntity>(createDto)) : default!;
            await _uow.SaveAsync();

            return Result<TShowDto>.CreateResult
                        (validatorError, entity, _mapper.Map<TShowDto>(entity), Message.CreateError);

        }


        public List<Result<TShowDto>> AddRange(IEnumerable<TCreateDto> dtos)
        {
            dtos = dtos.ToList();
            var validatorErrors = new List<List<ValidatorError>>();
            var isValid = true;
            List<TEntity> entities = default!;
            foreach (var dto in dtos)
            {
                validatorErrors.Add(ValidateResult.GetValidationResult(dto, out var _isValid));
                isValid = isValid && _isValid;
            }

            entities = isValid ? _uow.Write.AddRange(_mapper.Map<IEnumerable<TEntity>>(dtos)) : default!;
            _uow.Save();

            var results = dtos
                .Select((_, index) => Result<TShowDto>.CreateResult(
                        validatorErrors[index],
                        entities[index],
                        _mapper.Map<TShowDto>(entities[index]),
                        Message.CreateError
                    )).ToList();

            return results;

        }

        public void AddRangeAsync(IEnumerable<TEntity> entities)
        {
            _uow.Write.AddRangeAsync(entities);
            _uow.SaveAsync();
        }

        //todo: what if the entity is not found?
        public void Delete(TEntity entity)
        {
            _uow.Write.Remove(entity);
            _uow.Save();
        }

        //todo: what if the entity is not found?
        public TEntity DeleteById(int id)
        {
            var entity = _uow.Write.RemoveById(id);
            _uow.Save();
            return entity;
        }




        public void RemoveRange(IEnumerable<TEntity> entities)
        {
            _uow.Write.RemoveRange(entities);
            _uow.Save();
        }

        public void Update(TEntity entity)
        {
            _uow.Write.Update(entity);
            _uow.Save();
        }

        public void UpdateRange(IEnumerable<TEntity> entities)
        {
            _uow.Write.UpdateRange(entities);
            _uow.Save();
        }

        public IEnumerable<TEntity> FromSqlInterpolated(FormattableString sql)
        {
            return _uow.Write.FromSqlInterpolated(sql);
        }
    }
}

namespace App.Application.GenericService.WriteService.Share
{
    public class WriteService<TEntity, TCreateDto> :
    IWriteService<TEntity>
    where TEntity : Entity
    where TCreateDto : CreateDto

    {

        protected readonly IMapper _mapper;


        protected WriteService(IMapper mapper, IValidator<TCreateDto> validator)
        {
            _mapper = mapper;
        }


    }
}



