using Infrastructure.Data.DbContexts;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure
{
    public static class DependencyInjection
    {
        public static void RegisterInfrastructureDependencies(IServiceCollection services)
        {
            services.AddDbContext<ShelfieDbContext>();
        }

        public static void AddInfrastructureDbContext(IServiceCollection services, string connectionString)
        {
            services.AddDbContext<ShelfieDbContext>(options =>
            {
                options.UseSqlServer(connectionString);
            });
        }
    }
}
