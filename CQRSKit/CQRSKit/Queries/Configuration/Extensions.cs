using System.Reflection;
using CQRSKit.Queries.Abstractions;
using Microsoft.Extensions.DependencyInjection;

namespace CQRSKit.Queries.Configuration;

public static class Extensions
{
    internal static IServiceCollection AddQueries(this IServiceCollection services)
    {
        IEnumerable<Assembly> assemblies = AppDomain.CurrentDomain.GetAssemblies();
        return services.AddQueries(assemblies);
    }
    
    private static IServiceCollection AddQueries(this IServiceCollection services, IEnumerable<Assembly> assemblies)
    {
        services.Scan(s => s.FromAssemblies(assemblies)
            .AddClasses(c => c.AssignableTo(typeof(IQueryHandler<,>)))
            .AsImplementedInterfaces()
            .WithScopedLifetime());
        return services;
    }
}