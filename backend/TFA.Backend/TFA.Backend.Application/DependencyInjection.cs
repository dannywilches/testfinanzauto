using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using TFA.Backend.Application.Commands.Auth;
using TFA.Backend.Application.Interfaces.Auth;

namespace TFA.Backend.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            // Add application services here
            services.AddScoped<ILoginCommandHandler, LoginCommandHandler>();
            services.AddScoped<PasswordHasher<string>>();

            return services;
        }
    }
}
