using CQRSKit.Configuration;
using CQRSKit.FluentValidation.Decorators.Configuration;
using CQRSKit.FluentValidation.Middleware;
using CQRSKit.FluentValidation.Middleware.Configuration;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace CQRSKit.FluentValidation.Configuration;

public static class Extensions
{
    public static CqrsKitServiceCollection AddValidation(this CqrsKitServiceCollection cqrsKitServiceCollection,
        Action<CqrsKitFluentValidationBuilder> builder)
    {
        var builderInstance = new CqrsKitFluentValidationBuilder(cqrsKitServiceCollection.Services);
        builder(builderInstance);
        cqrsKitServiceCollection.Services
            .AddSingleton(builderInstance)
            .AddDecorators()
            .AddValidationMiddleware();
        return cqrsKitServiceCollection;
    }

    public static WebApplication UseValidation(this WebApplication app)
        => app.UseValidationMiddleware();
}