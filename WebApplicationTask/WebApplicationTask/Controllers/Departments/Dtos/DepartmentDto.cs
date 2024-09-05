using WebApplication.Domain.Departments;

namespace WebApplicationTask.Controllers.Departments.Dtos
{
    public class DepartmentDto
    {
        public int Id { get; set; }

        public string? Name { get; set; }

        public string? Logo { get; set; }

    }

    public class DepartmentDetailsDto : DepartmentDto 
    {
        public List<DepartmentDto> SubDepartmentsData { get; set; } = new List<DepartmentDto> { };
        public List<DepartmentDto> ParentDepartmentsData { get; set; } = new List<DepartmentDto> { };
    }
}
