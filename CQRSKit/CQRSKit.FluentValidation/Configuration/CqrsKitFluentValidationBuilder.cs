using Microsoft.Extensions.DependencyInjection;

namespace CQRSKit.FluentValidation.Configuration;

public sealed class CqrsKitFluentValidationBuilder
{
    private readonly IServiceCollection _services;
    internal bool AllCommands { get; private set; } = false;  

    public CqrsKitFluentValidationBuilder(IServiceCollection services)
    {
        _services = services;
    }
    
    public void SetRequiredCommandsValidation()
        => AllCommands = true;
    
    public void SetValidators(Func<IServiceCollection, IServiceCollection> services)
    {
        var servicesAction = services.Invoke(_services);
    }
    
}