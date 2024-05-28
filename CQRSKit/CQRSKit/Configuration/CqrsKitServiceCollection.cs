using Microsoft.Extensions.DependencyInjection;

namespace CQRSKit.Configuration;

public sealed record CqrsKitServiceCollection
{
    public IServiceCollection Services { get; private set; }

    private CqrsKitServiceCollection(IServiceCollection services)
        => Services = services;

    internal static CqrsKitServiceCollection Create(IServiceCollection services)
        => new CqrsKitServiceCollection(services);

}