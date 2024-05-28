using Microsoft.AspNetCore.Builder;

namespace CQRSKit.Configuration;

public sealed record CqrsKitApplication
{
    public WebApplication App { get; private set; }
    
    private CqrsKitApplication(WebApplication app)
        => App = app;

    internal static CqrsKitApplication Create(WebApplication app)
        => new CqrsKitApplication(app);
}