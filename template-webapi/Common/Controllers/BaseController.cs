using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using template_webapi.Common.Interfaces;
using template_webapi.Common.Response;

namespace template_webapi.Common.Controllers
{
    public class BaseController<TEntity, TResponse> : ControllerBase
    where TEntity : class
    where TResponse : class
    {
        protected readonly IGenericService<TEntity, TResponse> _service;

        public BaseController(IGenericService<TEntity, TResponse> service)
        {
            _service = service;
        }


        [HttpGet]
        public virtual async Task<IActionResult> GetAllAsync(CancellationToken cancellationToken)
        {
            var dtos = await _service.GetAllAsync(cancellationToken);
            return Ok(ApiResponse<IEnumerable<TResponse>>.Ok(dtos));
        }

    }
}
