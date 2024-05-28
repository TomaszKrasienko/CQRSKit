using System.Reflection;
using CQRSKit.Commands.Configuration;
using CQRSKit.Dispatchers.Configuration;
using CQRSKit.Logging.Configuration;
using CQRSKit.Queries.Configuration;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace CQRSKit.Configuration;

public static class Extensions
{
    public static CqrsKitServiceCollection AddCqrsKit(this IServiceCollection services, Action<CqrsKitBuilder> builder)
        => services.AddCqrsKit(null, builder);
    
    public static CqrsKitServiceCollection AddCqrsKit(this IServiceCollection services,
        IEnumerable<Assembly>? assemblies = null, Action<CqrsKitBuilder>? builder = null)
    {
        assemblies ??= AppDomain.CurrentDomain.GetAssemblies();
        services
            .AddCommands(assemblies)
            .AddQueries(assemblies)
            .AddDispatchers();

        if (builder is not null)
        {
            var builderInstance = new CqrsKitBuilder(services);
            builder(builderInstance);
            if (builderInstance.Logging)
            {
                services.AddCqrsKitLogging();
            }
        }
        
        return CqrsKitServiceCollection.Create(services);
    }

    public static IServiceCollection Configure(this CqrsKitServiceCollection cqrsKitServiceCollection)
        => cqrsKitServiceCollection.Services;

    public static CqrsKitApplication UseCqrsKit(this WebApplication app)
        => CqrsKitApplication.Create(app);
    
}