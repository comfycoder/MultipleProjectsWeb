using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MyApp.Contracts;
using MyApp.Services;
using MyApp.Web.DocumentFilters;
using Swashbuckle.AspNetCore.Annotations;
using Swashbuckle.AspNetCore.Filters;

namespace MyApp.Web.Controllers
{
    /// <summary>
    /// Customer API
    /// </summary>
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ICustomerService _customerService;

        public CustomersController(IMapper mapper, ICustomerService customerService)
        {
            _mapper = mapper;
            _customerService = customerService;
        }

        /// <summary>
        /// Get Customers
        /// </summary>
        /// <returns></returns>
        [HttpGet("", Name = "GetCustomers")]
        [SwaggerResponse(200, "The list of countries", typeof(IEnumerable<CustomerDto>))]
        [SwaggerResponseExample(200, typeof(CustomerExamples))]
        public async Task<IEnumerable<CustomerDto>> GetCustomers()
        {
            var customerEntities = await _customerService.GetCustomersAsync();

            var customers = _mapper.Map<IEnumerable<CustomerDto>>(customerEntities);

            return customers;
        }
    }
}
