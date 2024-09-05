using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using WebApplication.Domain.Departments;

namespace WebApplication.Data.Models.Departments
{
    internal class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Department, DepartmentDomain>().ReverseMap();
            CreateMap<Department, DepartmentDetailsDomain>().ReverseMap();
        }
    }
}
