using System.Reflection;
using Calendario.Core.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Calendario.Core;

public static class Extensions
{
    public static IServiceCollection AddCoreLayer(this IServiceCollection services)
    {
        services.AddMediatR(config => config.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
        
        services.AddScoped<IOAuthService, OAuthService>();

        return services;
    }
}