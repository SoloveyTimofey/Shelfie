using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Shelfie.Application.Common.Interfaces;
using Shelfie.Infrastructure.Data.DbContexts;
using Shelfie.Infrastructure.Identity;
using System.Reflection;
using System.Text;

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

            services.AddIdentityCore<ApplicationUser>()
                    .AddRoles<IdentityRole>()
                    .AddEntityFrameworkStores<ShelfieDbContext>()
                    .AddDefaultTokenProviders();

            services.Configure<IdentityOptions>(options =>
            {
                options.Password.RequireDigit = false;
                options.Password.RequireUppercase = false;
                options.Password.RequiredLength = 4;
                options.Password.RequireNonAlphanumeric = false;
            });

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {
                var secret = configuration["JwtConfiguration:Secret"];
                var issuer = configuration["JwtConfiguration:ValidIssuer"];
                var audience = configuration["JwtConfiguration:ValidAudiences"];
                if (secret is null || issuer is null || audience is null)
                {
                    throw new ApplicationException("Jwt is not set in the configuration");
                }
                options.SaveToken = true;
                options.RequireHttpsMetadata = false;
                options.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidAudience = audience,
                    ValidIssuer = issuer,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secret))
                };

            });

            services.AddScoped<IIdentityService, IdentityService>();

            return services;
        }
    }
}
