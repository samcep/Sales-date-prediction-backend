using Microsoft.AspNetCore.Mvc;
using template_webapi.Common.Response;
using template_webapi.Features.Orders.Dtos;
using template_webapi.Features.Orders.Service;

namespace template_webapi.Features.Orders.Controller
{
    [ApiController]
    [Route("api/orders")]
    public class OrderController : ControllerBase
    {

        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateOrder([FromBody] CreateOrderRequest request)
        {
            var validator = new CreateOrderRequestValidator();
            var validationResult = await validator.ValidateAsync(request);

            if (!validationResult.IsValid)
            {
                var errors = validationResult.Errors
                    .Select(e => e.ErrorMessage)
                    .ToList();

                return BadRequest(ApiResponse<string>.Fail("Error de validacion", errors));
            }

            var orderId = await _orderService.CreateOrderAsync(request);
            return Ok(ApiResponse<int>.Ok(orderId));
        }
    }
}
