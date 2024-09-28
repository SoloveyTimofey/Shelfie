using Microsoft.Extensions.DependencyInjection;
using Shelfie.Application.Mapping.Profiles;

namespace Shelfie.Application.Mapping
{
    public static class MappingServicesRegistration
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddAutoMapper(cfg =>
            {
                cfg.RecognizeDestinationPostfixes("Model");
            }, typeof(DomainToDatabaseProfile).Assembly);

            return services;
        }
    }
}
