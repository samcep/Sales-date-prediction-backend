using Microsoft.AspNetCore.Mvc;
using template_webapi.Common.Controllers;
using template_webapi.Common.Interfaces;
using template_webapi.Data.Entities;
using template_webapi.Features.Products.Dtos;
using template_webapi.Features.Shippers.Dtos;

namespace template_webapi.Features.Products.Controller
{
    [Route("api/products")]
    [ApiController]
    public class ProductController : BaseController<Product, ProductResponse>
    {
        public ProductController(
            IGenericService<Product, ProductResponse> service)
            : base(service)
        {
        }
    }
}
