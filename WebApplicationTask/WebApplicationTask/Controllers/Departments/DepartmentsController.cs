using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WebApplication.Data.Models.Departments;
using WebApplication.Domain.Departments;
using WebApplicationTask.Controllers.Departments.Dtos;

namespace WebApplicationTask.Controllers.Departments
{
    public class DepartmentsController : Controller
    {
        private readonly IDepartmentsManager _departmentsManager;
        private readonly IMapper _mapper;

        public DepartmentsController(IDepartmentsManager departmentsManager, IMapper mapper)
        {
            _departmentsManager = departmentsManager;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            var departments = await _departmentsManager.GetAllAsync();

            return View(_mapper.Map<List<DepartmentDto>>(departments));
        }

        public async Task<IActionResult> Details(int id)
        {
            var department = await _departmentsManager.GetAsync(id);

            var parentDepartments = _mapper.Map<List<DepartmentDto>>(department.ParentDepartmentsData);

            ViewBag.ParentDepartments = parentDepartments;

            return View(_mapper.Map<DepartmentDetailsDto>(department));
        }

    }
}
