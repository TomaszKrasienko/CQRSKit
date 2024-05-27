using CQRSKit.Configuration;
using CQRSKit.FluentValidation.Decorators.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CQRSKit.FluentValidation.Configuration;

public static class Extensions
{
    public static CqrsKitServiceCollection AddValidation(this CqrsKitServiceCollection cqrsKitServiceCollection,
        Action<CqrsKitFluentValidationBuilder> builder)
    {
        var builderInstance = new CqrsKitFluentValidationBuilder(cqrsKitServiceCollection.Services);
        builder(builderInstance);
        cqrsKitServiceCollection
            .Services.AddSingleton(builderInstance);
        cqrsKitServiceCollection.Services
            .AddDecorators();
        return cqrsKitServiceCollection;
    }
}