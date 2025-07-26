using template_webapi.Common.Interfaces;
using template_webapi.Data.Entities;
using template_webapi.Features.Customers.Dtos;

namespace template_webapi.Features.Customers.Interfaces
{
    public interface ICustomerRepository : IGenericRepository<Customer>
    {
        Task<IEnumerable<CustomerPredictionResponse>> GetCustomerNextOrderPredictions(CancellationToken cts);

        Task<IEnumerable<Order>> GetCustomerOrders(int id);

    }
}
