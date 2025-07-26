using AutoMapper;
using template_webapi.Data.Entities;
using template_webapi.Features.Employees.Dtos;

namespace template_webapi.Features.Employees.Mapping
{
    public class EmployeeProfile : Profile
    {
        public EmployeeProfile() 
        {
            CreateMap<Employee, EmployeeResponse>()
             .ConstructUsing(e => new EmployeeResponse(
                 e.Empid,
                 $"{e.Firstname} {e.Lastname}"
             ));
        }

    }
}
