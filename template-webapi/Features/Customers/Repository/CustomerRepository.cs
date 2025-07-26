using AutoMapper;
using Microsoft.EntityFrameworkCore;
using template_webapi.Common.Interfaces;
using template_webapi.Common.Repositories;
using template_webapi.Data;
using template_webapi.Data.Entities;
using template_webapi.Features.Customers.Dtos;
using template_webapi.Features.Customers.Interfaces;

namespace template_webapi.Features.Customers.Repository
{
    public class CustomerRepository : GenericRepository<Customer> , ICustomerRepository
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly ILogger<GenericRepository<Customer>> _logger;
        public CustomerRepository(ApplicationDbContext applicationDbContext,
            ILogger<CustomerRepository> logger) : base(applicationDbContext, logger)
        {
            _dbContext = applicationDbContext;
            _logger = logger;
        }

        public async Task<IEnumerable<CustomerPredictionResponse>> GetCustomerNextOrderPredictions(CancellationToken cts)
        {
            try
            {
                var query = @"
                WITH OrderHistoric AS ( 
                    SELECT 
                        O.custid,  
                        O.orderdate,
                        LAG(O.orderdate, 1, null) OVER (
                            PARTITION BY O.custid
                            ORDER BY O.orderdate
                        ) AS OrderPrev 
                    FROM Sales.Orders AS O
                ), 
                QuantityDays AS(
                    SELECT 
                        custid,
                        orderdate,
                        OrderPrev,
                        DATEDIFF(DAY, OrderPrev, orderdate) AS QDays
                    FROM OrderHistoric 
                ),
                AVGOrder AS(
                    SELECT 
                        custid,
                        MAX(orderdate) AS LastOrderDate,
                        AVG(CAST(QDays AS FLOAT)) AS AVGDays
                    FROM QuantityDays
                    GROUP BY custid
                )
                SELECT 
	                C.custid,
                    C.companyname AS CustomerName,
                    AO.LastOrderDate, 
                    DATEADD(DAY, AO.AVGDays, AO.LastOrderDate) AS NextPredictedOrder
                FROM AVGOrder AO
                INNER JOIN Sales.Customers C ON AO.custid = C.custid
                ORDER BY C.custid;";
                                
               
                var predictedOrders = await _dbContext
                    .Set<CustomerPredictionResponse>()
                    .FromSqlRaw(query) 
                    .ToListAsync(cts);

                return predictedOrders;
            }
            catch (Exception msg)
            {
                _logger.LogError($"Error while getting customer with predicted order {msg})");
                throw new ApplicationException($"Error while getting customer with predicted order {msg}");
            }
        }

        public async Task<IEnumerable<Order>> GetCustomerOrders(int id)
        {
            var orders = await _dbContext.Orders
                .Where(o => o.Custid == id)
                .ToListAsync();
            return orders;
        }
    }
}
