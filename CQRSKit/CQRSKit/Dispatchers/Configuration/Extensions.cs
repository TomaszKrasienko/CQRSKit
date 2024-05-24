using Microsoft.Extensions.DependencyInjection;

namespace CQRSKit.Dispatchers.Configuration;

internal static class Extensions
{
    internal static IServiceCollection AddDispatchers(this IServiceCollection services)
        => services;
}