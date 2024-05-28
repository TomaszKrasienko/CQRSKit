using CQRSKit.Commands.Abstractions;
using CQRSKit.Queries.Abstractions;
using Microsoft.Extensions.DependencyInjection;

namespace CQRSKit.Logging.Configuration;

internal static class Extensions
{
    internal static IServiceCollection AddCqrsKitLogging(this IServiceCollection services)
    {
        services.TryDecorate(typeof(ICommandHandler<>), typeof(CommandHandlerLogDecorator<>));
        services.TryDecorate(typeof(IQueryHandler<,>), typeof(QueryHandlerLogDecorator<,>));
        return services;
    }
}