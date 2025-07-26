using template_webapi.Features.Orders.Dtos;
using template_webapi.Features.Orders.Repository;

namespace template_webapi.Features.Orders.Service
{
    public interface IOrderService
    {
        Task<int> CreateOrderAsync(CreateOrderRequest request);
    }


    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;

        public OrderService(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }
        public async Task<int> CreateOrderAsync(CreateOrderRequest request)
        {
            return await _orderRepository.CreateOrderWithDetailAsync(request);
        }
    }

}
