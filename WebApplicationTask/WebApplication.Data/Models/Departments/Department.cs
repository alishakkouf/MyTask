using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication.Domain.Auditing;

namespace WebApplication.Data.Models.Departments
{
    public class Department : IAuditedEntity
    {
        public int Id { get; set; }

        public string? Name { get; set; }

        /// <summary>
        /// relative path to the department logo
        /// </summary>
        public string? Logo { get; set; }

        public int? ParentDepartmentId { get; set; }

        public long? CreatorUserId { get; set; }

        public DateTime? CreatedAt { get; set; } = DateTime.UtcNow;

        public long? ModifierUserId { get; set; }

        public DateTime? ModifiedAt { get; set; }

        public bool? IsDeleted { get; set; } = false;

        public Department ParentDepartment { get; set; }

        public ICollection<Department> SubDepartments { get; set; } = [];
    }
}
