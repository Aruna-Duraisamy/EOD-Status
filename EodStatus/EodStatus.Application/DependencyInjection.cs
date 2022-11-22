using EodStatus.Application.Services.Authentication;
using Microsoft.Extensions.DependencyInjection;

namespace EodStatus.Application;
public static class DependencyInjection
{
    public static IServiceCollection AddApplicationDependencies(this IServiceCollection services)
    {
        services.AddScoped<IAuthenticationService, AuthenticationService>();
        return services;
    }
}
