using System.Runtime.Serialization;
using Microsoft.Extensions.DependencyInjection;

namespace CQRSKit.Configuration;

public class CqrsKitBuilder
{
    private readonly IServiceCollection _services;
    internal bool Logging { get; set; }

    public CqrsKitBuilder(IServiceCollection services)
    {
        _services = services;
    }

    public void EnableLogging()
        => Logging = true;

    public void SetValidators(Func<IServiceCollection, IServiceCollection> services)
    {
        var servicesAction = services.Invoke(_services);
    }
}