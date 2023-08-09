using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using InfraData.Context;
using Microsoft.EntityFrameworkCore;
using Domain.Repositories;
using InfraData.Repositories;
using Service.Mapping;
using Service.Interfaces;
using Service.Services;
using Domain.Authentication;
using InfraData.Authentication;

namespace CrossCutting.Configuration
{
    public static class DependencyInjection
    {

        
        public static IServiceCollection AddInfrastruture(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ContextDb>(options => options.UseNpgsql(configuration.GetConnectionString("DefaultConnection")));
            services.AddScoped<IPersonRepository, PersonRepository>();
            services.AddScoped<INoteRepository, NoteRepository>();
            services.AddScoped<ITokenGenarator, TokenGenerator>();
            return services;
        }
        public static IServiceCollection AddServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IPersonService, PersonService>();
            services.AddScoped<INoteService, NoteService>();
            services.AddAutoMapper(typeof(DomainToDTO));
            return services;
        }
    }
}
