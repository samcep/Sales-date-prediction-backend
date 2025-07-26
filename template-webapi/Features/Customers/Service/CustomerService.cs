using AutoMapper;
using template_webapi.Common.Interfaces;
using template_webapi.Common.Services;
using template_webapi.Data.Entities;
using template_webapi.Features.Clients.Dtos;
using template_webapi.Features.Customers.Dtos;
using template_webapi.Features.Customers.Interfaces;

namespace template_webapi.Features.Customers.Service
{
    public class CustomerService : GenericService<Customer, CustomerResponse>, ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IMapper _mapper;
        public CustomerService(
            ICustomerRepository repository,
            IMapper mapper) : base(repository, mapper) 
        {
            _customerRepository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<CustomerPredictionResponse>> GetCustomerNextOrderPredictions(CancellationToken cts)
        {
            try
            {
                return await _customerRepository.GetCustomerNextOrderPredictions(cts);
            }
            catch (Exception) 
            {
                throw;
            }
            
        }

        public async Task<IEnumerable<CustomerOrder>> GetCustomerOrders(int id)
        {
            try
            {
                var orders = await _customerRepository.GetCustomerOrders(id) ?? new List<Order>();
                var customerOrders = _mapper.Map<IEnumerable<CustomerOrder>>(orders);

                return customerOrders;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
