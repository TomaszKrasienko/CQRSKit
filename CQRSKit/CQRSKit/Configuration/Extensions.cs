using System.Reflection;
using CQRSKit.Commands.Configuration;
using CQRSKit.Dispatchers.Configuration;
using CQRSKit.Logging.Configuration;
using CQRSKit.Queries.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CQRSKit.Configuration;

public static class Extensions
{
    public static IServiceCollection AddCqrsKit(this IServiceCollection services, Action<CqrsKitBuilder> builder)
        => services.AddCqrsKit(null, builder);
    
    public static IServiceCollection AddCqrsKit(this IServiceCollection services,
        IEnumerable<Assembly>? assemblies = null, Action<CqrsKitBuilder>? builder = null)
    {
        assemblies ??= AppDomain.CurrentDomain.GetAssemblies();
        services
            .AddCommands(assemblies)
            .AddQueries(assemblies)
            .AddDispatchers();

        if (builder is not null)
        {
            var builderInstance = new CqrsKitBuilder();
            builder(builderInstance);
            if (builderInstance.Logging)
            {
                services.AddLogging();
            }
        }
        
        return services;
    }
    
    
}