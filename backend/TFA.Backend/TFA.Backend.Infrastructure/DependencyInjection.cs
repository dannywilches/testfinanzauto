using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TFA.Backend.Infrastructure.Authentication;
using TFA.Backend.Infrastructure.Persistence;

namespace TFA.Backend.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            // Persistence
            services.AddAuthenticationServices(configuration);
            services.AddPersistence(configuration);
            return services;
        }
    }
}
