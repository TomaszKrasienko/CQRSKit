using CQRSKit.Commands.Abstractions;
using Microsoft.Extensions.DependencyInjection;

namespace CQRSKit.Logging.Configuration;

internal static class Extensions
{
    private static IServiceCollection AddLogging(this IServiceCollection services)
    {
        services.TryDecorate(typeof(ICommandHandler<>), typeof(CommandHandlerLogDecorator<>));
        return services;
    }
}