using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication.Domain.Departments;
using WebApplication.Domain.Reminders;

namespace WebApplication.Manager
{
    public class DepartmentManager : IDepartmentsManager
    {
        private readonly IDepartmentsProvider _departmentsProvider;

        public DepartmentManager(IDepartmentsProvider departmentsProvider)
        {
            _departmentsProvider = departmentsProvider;
        }

        public async Task<List<DepartmentDomain>> GetAllAsync()
        {
            return await _departmentsProvider.GetAllAsync();
        }

        public async Task<DepartmentDetailsDomain> GetAsync(int id)
        {
            return await _departmentsProvider.GetAsync(id);
        }
    }
}
