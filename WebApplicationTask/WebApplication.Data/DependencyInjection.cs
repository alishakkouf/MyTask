using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WebApplication.Data.Providers;
using WebApplication.Domain.Departments;
using WebApplication.Domain.Reminders;

namespace WebApplication.Data
{
    public static class DependencyInjection
    {
        public static IServiceCollection ConfigureDataModule(this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddTransient<IReminderProvider, ReminderProvider>();
            services.AddTransient<IDepartmentsProvider, DepartmentProvider>();
            return services;
        }
    }
}
