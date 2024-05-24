namespace CQRSKit.Configuration;

public class CqrsKitBuilder
{
    internal bool Logging { get; set; }

    public void EnableLogging()
        => Logging = true;
}