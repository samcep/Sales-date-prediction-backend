using System;
using template_webapi.Data;
using template_webapi.Data.Entities;
using template_webapi.Features.Orders.Dtos;

namespace template_webapi.Features.Orders.Repository
{
    public interface IOrderRepository
    {
        Task<int> CreateOrderWithDetailAsync(CreateOrderRequest request);
    }
    public class OrderRepository : IOrderRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public OrderRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<int> CreateOrderWithDetailAsync(CreateOrderRequest request)
        {
            using var transaction = await _dbContext.Database.BeginTransactionAsync();

            try
            {
                var order = new Order
                {
                    Empid = request.Empid,
                    Shipperid = request.Shipperid,
                    Shipname = request.Shipname,
                    Shipaddress = request.Shipaddress,
                    Shipcity = request.Shipcity,
                    Shipcountry = request.Shipcountry,
                    Orderdate = request.Orderdate,
                    Requireddate = request.Requireddate,
                    Shippeddate = request.Shippeddate,
                    Freight = request.Freight
                };

                _dbContext.Orders.Add(order);
                await _dbContext.SaveChangesAsync();

                var orderDetail = new OrderDetail
                {
                    Orderid = order.Orderid,
                    Productid = request.Productid,
                    Unitprice = request.Unitprice,
                    Qty = request.Qty,
                    Discount = request.Discount
                };

                _dbContext.OrderDetails.Add(orderDetail);
                await _dbContext.SaveChangesAsync();

                await transaction.CommitAsync();

                return order.Orderid;
            }
            catch
            {
                await transaction.RollbackAsync();
                throw;
            }
        }
    }
}
