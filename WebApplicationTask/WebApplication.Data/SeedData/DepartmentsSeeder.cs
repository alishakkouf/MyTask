using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication.Data.Models.Departments;
using WebApplication.Data.Models.Reminders;

namespace WebApplication.Data.SeedData
{
    public class DepartmentsSeeder : IDataSeeder
    {
        public void Seed(ApplicationDbContext _context)
        {
            Console.WriteLine("Seeding Departments...");

            // Check if there are any existing Departments to avoid seeding duplicates
            if (_context.Departments.Any())
            {
                Console.WriteLine("Departments already exist. Skipping seed.");
                return;
            }

            var departments = new List<Department>
            {
                new Department
                {
                    Name = "Department 1 has no parent", Logo = ""
                },
                new Department
                {
                     Name = "Department 2 has no parent", Logo = "",SubDepartments = new List<Department>
                     {
                         new Department{ Name = "Department 3 has parent", Logo = "" }                     
                     }
                }
            };

            // Add the Departments to the context and save changes
            _context.Departments.AddRange(departments);
            _context.SaveChanges();

            Console.WriteLine("Departments seeding complete.");
        }
    }
}


