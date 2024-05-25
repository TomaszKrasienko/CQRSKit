using CQRSKit.Dispatchers.Abstractions;
using CQRSKit.Dispatchers.Internals;
using Microsoft.Extensions.DependencyInjection;

namespace CQRSKit.Dispatchers.Configuration;

internal static class Extensions
{
    internal static IServiceCollection AddDispatchers(this IServiceCollection services)
        => services.AddSingleton<ICqrsDispatcher, CqrsDispatcher>();
}