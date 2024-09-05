using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication.Domain.Departments
{
    public class DepartmentDomain
    {
        public int Id { get; set; }

        public string? Name { get; set; }

        public string? Logo { get; set; }

    }

    public class DepartmentDetailsDomain : DepartmentDomain
    {
        public List<DepartmentDomain> SubDepartmentsData { get; set; } = new List<DepartmentDomain> { };
        public List<DepartmentDomain> ParentDepartmentsData { get; set; } = new List<DepartmentDomain> { };
    }
}
