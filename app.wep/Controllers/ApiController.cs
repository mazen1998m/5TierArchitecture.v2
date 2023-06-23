using app.core.EntityAndDtoStructure.DtoStructure;
using app.core.EntityAndDtoStructure.EntityStructure;
using App.Application.Customers.Dtos.CreateDto;
using App.Application.GenericService.BaseService;
using App.Application.GenericService.BaseService.Include;
using App.Application.GenericService.BaseService.Include.Filter;
using App.core;
using App.core.Filter;
using Microsoft.AspNetCore.Mvc;

namespace App.web.Controllers
{
    public class ApiController<TEntity, TCreateDto, TShowDto> : Share.ApiController
        where TEntity : Entity where TCreateDto : CreateDto where TShowDto : ShowDto

    {
        private readonly IService<TEntity, TCreateDto, TShowDto> _service;

        public ApiController(IService<TEntity, TCreateDto, TShowDto> service) { _service = service; }

        [HttpGet] public IActionResult Get(int id) => Ok(_service.Read.GetById(id));

        [HttpGet] public IActionResult GetAll(IFilter<TEntity>? filter) => Ok(_service.Read.GetAllAsync(filter));

        [HttpGet] public IActionResult Find(string filter) => Ok(_service.Read.Find(x => x.CreatedBy == filter));


        [HttpPost] public IActionResult Create(TCreateDto customerDto) => Ok(_service.Write.Create(customerDto));


        [HttpPost] public IActionResult Update(CustomerCreateDto customerDto) => Ok();


        [HttpDelete] public IActionResult Delete(int id) => Ok(_service.Write.DeleteById(id));

    }
}

namespace App.web.Controllers.Include
{

    public class ApiController<TEntity, TCreateDto, TShowDto, TInclude> : Share.ApiController
        where TEntity : Entity where TCreateDto : CreateDto where TShowDto : ShowDto where TInclude : BaseInclude<TEntity>, new()

    {
        private readonly IService<TEntity, TCreateDto, TShowDto, TInclude> _service;
        public ApiController(IService<TEntity, TCreateDto, TShowDto, TInclude> service) { _service = service; }

        [HttpGet] public IActionResult Get(int id, [FromQuery] string[]? include) => Ok(_service.Read.GetById(id, include));


        [HttpGet] public IActionResult GetAll([FromQuery] string[]? include, IFilter<TEntity>? filter) => Ok(_service.Read.GetAllAsync(include, filter));


        [HttpGet] public IActionResult Find(string filter, [FromQuery] string[]? include) => Ok(_service.Read.Find(x => x.CreatedBy == filter, include));


        [HttpPost] public IActionResult Create(TCreateDto customerDto) => Ok(_service.Write.Create(customerDto));


        [HttpPost] public IActionResult Update(CustomerCreateDto customerDto) => Ok();


        [HttpDelete] public IActionResult Delete(int id) => Ok(_service.Write.DeleteById(id));


    }
}

namespace App.web.Controllers.Filter
{

    public class ApiController<TEntity, TCreateDto, TShowDto, TFilter> : Share.ApiController
        where TEntity : Entity where TCreateDto : CreateDto where TShowDto : ShowDto where TFilter : Filter<TEntity>, new()
    {
        private readonly Application.GenericService.BaseService.Filter.IService<TEntity, TCreateDto, TShowDto, TFilter> _service;


        public ApiController(Application.GenericService.BaseService.Filter.IService<TEntity, TCreateDto, TShowDto, TFilter> service) { _service = service; }

        [HttpGet] public IActionResult Get(int id) => Ok(_service.Read.GetById(id));


        [HttpGet] public IActionResult GetAll(IFilter<TEntity>? filter) => Ok(_service.Read.GetAllAsync(filter));


        [HttpGet] public IActionResult Find(string filter) => Ok(_service.Read.Find(x => x.CreatedBy == filter));


        [HttpPost] public IActionResult Create(TCreateDto customerDto) => Ok(_service.Write.Create(customerDto));


        [HttpPost] public IActionResult Update(CustomerCreateDto customerDto) => Ok();


        [HttpDelete] public IActionResult Delete(int id) => Ok(_service.Write.DeleteById(id));


    }
}

namespace App.web.Controllers.Include.Filter
{

    public class ApiController<TEntity, TCreateDto, TShowDto, TInclude, TFilter> : Share.ApiController
        where TEntity : Entity where TCreateDto : CreateDto where TShowDto : ShowDto
        where TInclude : BaseInclude<TEntity>, new() where TFilter : Filter<TEntity>, new()
    {
        private readonly IService<TEntity, TCreateDto, TShowDto, TInclude, TFilter> _service;

        public ApiController(IService<TEntity, TCreateDto, TShowDto, TInclude, TFilter> service) { _service = service; }

        [HttpGet] public IActionResult Get(int id, [FromQuery] string[]? include) => Ok(_service.Read.GetById(id, include));

        [HttpGet] public IActionResult GetAll([FromQuery] string[]? include, IFilter<TEntity>? filter) => Ok(_service.Read.GetAllAsync(include, filter));

        [HttpGet] public IActionResult Find(string filter, [FromQuery] string[]? include) => Ok(_service.Read.Find(x => x.CreatedBy == filter, include));

        [HttpPost] public IActionResult Create(TCreateDto customerDto) => Ok(_service.Write.Create(customerDto));

        [HttpPost] public IActionResult Update(CustomerCreateDto customerDto) => Ok();

        [HttpDelete] public IActionResult Delete(int id) => Ok(_service.Write.DeleteById(id));


    }
}

namespace App.web.Controllers.Share
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class ApiController : ControllerBase

    { }
}




