using CustomerCruncher.Application.Common.Interfaces;
using CustomerCruncher.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CustomerCruncher.Infrastructure
{
    public static class DependencyInjection
    {

        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseInMemoryDatabase("CustomerCruncher"));

            services.AddScoped<IApplicationDbContext>(provider => provider.GetService<ApplicationDbContext>());


            return services;
        }
    }
}
