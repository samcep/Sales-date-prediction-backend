
using Microsoft.AspNetCore.Mvc;
using template_webapi.Common.Controllers;
using template_webapi.Common.Response;
using template_webapi.Data.Entities;
using template_webapi.Features.Clients.Dtos;
using template_webapi.Features.Customers.Dtos;
using template_webapi.Features.Customers.Interfaces;

namespace template_webapi.Features.Clients.Controller
{
    [Route("api/customers")]
    [ApiController]
    public class CustomerController : BaseController<Customer, CustomerResponse>
    {
        private readonly ICustomerService _customerService;
        public CustomerController(
            ICustomerService service)
            : base(service)
        {
            _customerService = service;
        }

        [HttpGet("predictions")]
        public async Task<IActionResult> GetCustomerNextOrderPredictions(CancellationToken cts)
        {
            var result = await _customerService.GetCustomerNextOrderPredictions(cts);
            return Ok(ApiResponse<IEnumerable<CustomerPredictionResponse>>.Ok(result));
        }

        [HttpGet("{id:int}/orders")]
        public async Task<IActionResult> GetCustomerOrders(int id)
        {
            if(id == 0 || id < 0)
            {
                return BadRequest(ApiResponse<string>.Fail("Invalid Id cannot be zero or less than zero"));
            }
            var result = await _customerService.GetCustomerOrders(id);
            return Ok(ApiResponse<IEnumerable<CustomerOrder>>.Ok(result));
        }


    }
}
