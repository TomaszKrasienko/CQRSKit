using CQRSKit.Configuration;

namespace CQRSKit.FluentValidation.Configuration;

public static class Extensions
{
    public static CqrsKitServiceCollection AddValidation(this CqrsKitServiceCollection cqrsKitServiceCollection)
    {
        return cqrsKitServiceCollection;
    }
}