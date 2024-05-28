namespace CQRSKit.FluentValidation.Types;

public class ValidationErrorDto
{
    private readonly Type _commandType;
    public string CommandType => _commandType.Name;
    public List<string> Messages { get; private set; }

    internal ValidationErrorDto(Type commandType, List<string> messages)
    {
        _commandType = commandType;
        Messages = messages;
    }
}