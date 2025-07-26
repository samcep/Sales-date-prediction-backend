using AutoMapper;
using template_webapi.Data.Entities;
using template_webapi.Features.Employees.Dtos;
using template_webapi.Features.Shippers.Dtos;

namespace template_webapi.Features.Shippers.Mapping
{
    public class ShipperProfile : Profile
    {
        public ShipperProfile()
        {
            CreateMap<Shipper, ShipperResponse>()
           .ConstructUsing(e => new ShipperResponse(
               e.Shipperid,
               e.Companyname
           ));
        }
    }
}
