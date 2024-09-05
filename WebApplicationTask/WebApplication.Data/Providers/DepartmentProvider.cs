using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebApplication.Data.Models.Departments;
using WebApplication.Domain.Departments;
using WebApplication.Domain.Reminders;
using WebApplication.Shared.Exceptions;

namespace WebApplication.Data.Providers
{
    internal class DepartmentProvider : GenericProvider<Department>, IDepartmentsProvider
    {
        private readonly IMapper _mapper;

        public DepartmentProvider( ApplicationDbContext context, IMapper mapper)
        {
            DbContext = context;
            _mapper = mapper;
        }

        public async Task<List<DepartmentDomain>> GetAllAsync()
        {
            var data = await ActiveDbSet.ToListAsync();

            return _mapper.Map<List<DepartmentDomain>>(data);
        }

        public async Task<DepartmentDetailsDomain> GetAsync(int departmentId)
        {
            var department = await ActiveDbSet.Include(d => d.SubDepartments)
                                              .ThenInclude(sd => sd.SubDepartments) 
                                              .Include(d => d.ParentDepartment)
                                              .FirstOrDefaultAsync(d => d.Id == departmentId)
                                              ?? throw new EntityNotFoundException(nameof(Department), departmentId.ToString());

            //the result
            var toBeReturned = _mapper.Map<DepartmentDetailsDomain>(department);

            var subDepartments = department.SubDepartments.ToList();
                        
            ExpandSubDepartments(subDepartments);

            var parents = new List<Department>();

            var currentDepartment = department;

            while (currentDepartment.ParentDepartment != null)
            {
                parents.Add(currentDepartment.ParentDepartment);
                currentDepartment = currentDepartment.ParentDepartment; //To break while loop
            }

            toBeReturned.SubDepartmentsData = _mapper.Map<List<DepartmentDomain>>(subDepartments);
            toBeReturned.ParentDepartmentsData = _mapper.Map<List<DepartmentDomain>>(parents);

            return toBeReturned;
        }

        /// <summary>
        /// Function to recursively add nested sub-departments
        /// </summary>
        private void ExpandSubDepartments(List<Department> subDepartments)
        {
            foreach (var subDepartment in subDepartments.ToList())
            {
                subDepartments.AddRange(subDepartment.SubDepartments);

                // Recursive call for nested sub-departments
                ExpandSubDepartments(subDepartment.SubDepartments.ToList()); 
            }
        }

    }

}

