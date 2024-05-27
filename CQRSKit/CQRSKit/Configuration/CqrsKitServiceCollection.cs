using Microsoft.Extensions.DependencyInjection;

namespace CQRSKit.Configuration;

public sealed record CqrsKitServiceCollection(IServiceCollection Services);