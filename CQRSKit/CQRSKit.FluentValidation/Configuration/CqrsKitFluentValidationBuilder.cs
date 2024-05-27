namespace CQRSKit.FluentValidation.Configuration;

public sealed class CqrsKitFluentValidationBuilder
{
    internal bool AllCommands { get; private set; } = false;  

    public void SetRequiredCommandsValidation()
        => AllCommands = true;
}