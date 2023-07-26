using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using InfraData.Context;
using Microsoft.EntityFrameworkCore;
using Domain.Repositories;
using InfraData.Repositories;

namespace CrossCutting.Configuration
{
    public static class DependencyInjection
    {

        
        public static IServiceCollection AddInfrastruture(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ContextDb>(options => options.UseNpgsql(configuration.GetConnectionString("DefaultConnection")));
            services.AddScoped<IPersonRepository, PersonRepository>();

            return services;
        }
        public static IServiceCollection AddServices(this IServiceCollection services, IConfiguration configuration)
        {
           
            return services;
        }
    }
}
