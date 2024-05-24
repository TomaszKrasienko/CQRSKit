using System;
using System.Collections.Generic;
using System.Reflection;
using CQRSKit.Commands.Abstractions;
using Microsoft.Extensions.DependencyInjection;

namespace CQRSKit.Commands.Configuration;

internal static class Extensions
{
    internal static IServiceCollection AddCommands(this IServiceCollection services)
    {
        IEnumerable<Assembly> assemblies = AppDomain.CurrentDomain.GetAssemblies();
        return services.AddCommands(assemblies);
    }

    private static IServiceCollection AddCommands(this IServiceCollection services, IEnumerable<Assembly> assemblies)
    {
        services.Scan(s => s.FromAssemblies(assemblies)
            .AddClasses(c => c.AssignableTo(typeof(ICommandHandler<>)))
            .AsImplementedInterfaces()
            .WithScopedLifetime());
        return services;
    }
}