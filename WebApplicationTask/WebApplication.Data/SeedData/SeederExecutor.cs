using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication.Data.SeedData
{
    public class SeederExecutor
    {
        private readonly ApplicationDbContext _context;

        public SeederExecutor(ApplicationDbContext context)
        {
            _context = context;
        }

        public void ExecuteSeeders()
        {
            
            // Get all types in the current assembly that implement IDataSeeder
            var seederTypes = Assembly.GetExecutingAssembly().GetTypes()
                                      .Where(t => typeof(IDataSeeder)
                                      .IsAssignableFrom(t) && !t.IsInterface && !t.IsAbstract)
                                      .ToList();

            foreach (var seederType in seederTypes)
            {
                // Create an instance of the seeder
                var seeder = (IDataSeeder)Activator.CreateInstance(seederType);

                // Call the Seed method
                seeder.Seed(_context);
            }
        }
    }

}
