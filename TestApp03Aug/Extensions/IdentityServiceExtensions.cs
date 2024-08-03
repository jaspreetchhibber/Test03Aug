using TestApp03Aug.BLL.Interfaces;
using TestApp03Aug.BLL.Services;
using TestApp03Aug.DAL.Interfaces;
using TestApp03Aug.DAL.Repositiories;

namespace MedicalWriting.Extensions
{
    public static class IdentityServiceExtensions
    {
        public static IServiceCollection AddIdentityServices(this IServiceCollection services, IConfiguration config) 
        {
            //repositories
            services.AddScoped<IEmployeeRepository, EmployeeRepository>();
            services.AddScoped<IEmployeeSalaryRepository, EmployeeSalaryRepository>();

            //services
            services.AddScoped<IEmployeeService, EmployeeService>();
            services.AddScoped<IEmployeeSalaryService, EmployeeSalaryService>();
            return services;
        }
    }
}
