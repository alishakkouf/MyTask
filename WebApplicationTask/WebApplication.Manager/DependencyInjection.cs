using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WebApplication.Domain.Departments;
using WebApplication.Domain.Reminders;

namespace WebApplication.Manager
{
    public static class DependencyInjection
    {
        public static IServiceCollection ConfigureManagerModule(this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddTransient<IReminderManager, ReminderManager>();
            services.AddTransient<IDepartmentsManager, DepartmentManager>();
            return services;
        }
    }
}
