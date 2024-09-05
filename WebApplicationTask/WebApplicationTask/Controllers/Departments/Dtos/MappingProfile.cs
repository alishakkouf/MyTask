using AutoMapper;
using WebApplication.Domain.Departments;

namespace WebApplicationTask.Controllers.Departments.Dtos
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<DepartmentDomain, DepartmentDto>();
            CreateMap<DepartmentDetailsDomain, DepartmentDetailsDto>();
        }
    }
}
