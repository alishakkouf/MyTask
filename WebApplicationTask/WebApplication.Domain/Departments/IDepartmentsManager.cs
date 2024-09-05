using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication.Domain.Departments
{
    public interface IDepartmentsManager
    {
        /// <summary>
        /// Get all departments
        /// </summary>
        /// <returns></returns>
        Task<List<DepartmentDomain>> GetAllAsync();

        /// <summary>
        /// Get Department Details
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<DepartmentDetailsDomain> GetAsync(int id);
    }
}
