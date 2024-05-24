using System.Reflection;
using CQRSKit.Commands.Configuration;
using CQRSKit.Dispatchers.Configuration;
using CQRSKit.Queries.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CQRSKit.Configuration;

public static class Extensions
{
    public static IServiceCollection AddCqrsKit(this IServiceCollection services,
        IEnumerable<Assembly>? assemblies = null)
    {
        assemblies ??= AppDomain.CurrentDomain.GetAssemblies();
        services
            .AddCommands(assemblies)
            .AddQueries(assemblies)
            .AddDispatchers();
        return services;
    }  
}