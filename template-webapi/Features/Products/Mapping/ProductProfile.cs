using AutoMapper;
using template_webapi.Data.Entities;
using template_webapi.Features.Products.Dtos;
using template_webapi.Features.Shippers.Dtos;

namespace template_webapi.Features.Products.Mapping
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<Product, ProductResponse>()
             .ConstructUsing(e => new ProductResponse(
                 e.Productid,
                 e.Productname
             ));
        }
    }
}
