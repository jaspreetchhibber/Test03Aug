using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using TestApp03Aug.DAL;
using Newtonsoft.Json.Serialization;

namespace MedicalWriting.Extensions
{
    public static class ApplicationServiceExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration config)
        {
            services.AddDbContext<TestAppDbContext>(options =>
                options.UseSqlServer(config.GetConnectionString("DefaultConnection")));
            services.AddMvc().AddNewtonsoftJson(options=>
            {
                options.SerializerSettings.ContractResolver = new DefaultContractResolver();
                options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
            });

            return services;
        }
    }
}
