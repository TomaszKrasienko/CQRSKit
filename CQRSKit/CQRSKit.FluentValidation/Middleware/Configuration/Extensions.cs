using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace CQRSKit.FluentValidation.Middleware.Configuration;

internal static class Extensions
{
    internal static IServiceCollection AddValidationMiddleware(this IServiceCollection services)
        => services.AddSingleton<ValidationMiddleware>();

    internal static WebApplication UseValidationMiddleware(this WebApplication app)
    {
        app.UseMiddleware<ValidationMiddleware>();
        return app;
    }
}