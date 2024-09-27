using Infrastructure.Data.DbContexts;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Infrastructure
{
    public static class InfrastructureServicesRegistration
    {
        //public static void RegisterInfrastructureServices(IServiceCollection services, IConfiguration configuration)
        //{
        //    services.AddDbContext<ShelfieDbContext>(options =>
        //    {
        //        options.UseSqlServer(configuration.GetConnectionString("ShelfieConnection"),
        //            b => b.MigrationsAssembly("Infrastructure"));
        //    });
        //}
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            return services;
        }
    }
}
