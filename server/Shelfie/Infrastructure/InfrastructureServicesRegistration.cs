using Shelfie.Infrastructure.Data.DbContexts;
using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Shelfie.Infrastructure
{
    public static class InfrastructureServicesRegistration
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            Console.WriteLine(Assembly.GetExecutingAssembly().GetName().Name);
            services.AddDbContext<ShelfieDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("ShelfieConnection"),
                    b => b.MigrationsAssembly(Assembly.GetExecutingAssembly().GetName().Name));
            });

            return services;
        }
    }
}
