using CQRSKit.Commands.Abstractions;
using CQRSKit.Queries.Abstractions;
using Microsoft.Extensions.DependencyInjection;

namespace CQRSKit.Logging.Configuration;

internal static class Extensions
{
    private static IServiceCollection AddLogging(this IServiceCollection services)
    {
        services.TryDecorate(typeof(ICommandHandler<>), typeof(CommandHandlerLogDecorator<>));
        services.TryDecorate(typeof(IQueryHandler<,>), typeof(QueryHandlerLogDecorator<,>));
        return services;
    }
}