using template_webapi.Common.Interfaces;
using template_webapi.Data.Entities;
using template_webapi.Features.Clients.Dtos;
using template_webapi.Features.Customers.Dtos;

namespace template_webapi.Features.Customers.Interfaces
{
    public interface ICustomerService : IGenericService<Customer , CustomerResponse>
    {
        Task<IEnumerable<CustomerPredictionResponse>> GetCustomerNextOrderPredictions(CancellationToken cts);

        Task<IEnumerable<CustomerOrder>> GetCustomerOrders(int id);
    }
}
