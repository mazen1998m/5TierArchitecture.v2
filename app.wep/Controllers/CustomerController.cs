using app.Domain.Humans.Customers;
using App.Application.Customers.Dtos.CreateDto;
using App.Application.Customers.Dtos.ShowDto;
using App.Application.GenericService.BaseService.Include.Filter;
using App.Data.IncludeConfig;
using App.web.Controllers.Include.Filter;

namespace App.web.Controllers
{
    public class CustomerController : ApiController<Customer, CustomerCreateDto, CustomerShowDto, CustomerInclude, CustomerFilter>
    {
        public CustomerController(IService<Customer, CustomerCreateDto, CustomerShowDto, CustomerInclude, CustomerFilter> service)
            : base(service)
        {

        }

    }
}
