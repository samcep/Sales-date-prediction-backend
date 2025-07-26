using Microsoft.AspNetCore.Mvc;
using template_webapi.Common.Controllers;
using template_webapi.Common.Interfaces;
using template_webapi.Data.Entities;
using template_webapi.Features.Employees.Dtos;

namespace template_webapi.Features.Employees.Controller
{
    [Route("api/employees")]
    [ApiController]
    public class EmployeeController : BaseController<Employee, EmployeeResponse>
    {
        public EmployeeController(
            IGenericService<Employee, EmployeeResponse> service)
            : base(service)
        {
        }
    }
}
