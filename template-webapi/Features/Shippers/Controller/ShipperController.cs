using Microsoft.AspNetCore.Mvc;
using template_webapi.Common.Controllers;
using template_webapi.Common.Interfaces;
using template_webapi.Data.Entities;
using template_webapi.Features.Shippers.Dtos;

namespace template_webapi.Features.Shippers.Controller
{
    [Route("api/shippers")]
    [ApiController]
    public class ShipperController : BaseController<Shipper, ShipperResponse>
    {
        public ShipperController(
            IGenericService<Shipper, ShipperResponse> service)
            : base(service)
        {
        }
    }
}
