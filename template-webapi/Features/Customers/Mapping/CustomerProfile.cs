using AutoMapper;
using template_webapi.Data.Entities;
using template_webapi.Features.Customers.Dtos;


namespace template_webapi.Features.Clients.Mapping
{
    public class CustomerProfile : Profile
    {
        public CustomerProfile()
        {
            CreateMap<Order, CustomerOrder>();
        }
    }
}
