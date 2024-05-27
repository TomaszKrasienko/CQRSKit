using CQRSKit.Commands.Abstractions;
using Microsoft.Extensions.DependencyInjection;

namespace CQRSKit.FluentValidation.Decorators.Configuration;

internal static class Extensions
{
    internal static IServiceCollection AddDecorators(this IServiceCollection services)
    {
        services.TryDecorate(typeof(ICommandHandler<>), typeof(FluentValidationCommandHandlerDecorator<>));
        return services;
    }
}