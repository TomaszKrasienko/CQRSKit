namespace CQRSKit.FluentValidation.Types;

public class ValidationErrorDto
{
    public Type CommandType { get; private set; }
    public List<string> Messages { get; private set; }

    internal ValidationErrorDto(Type commandType, List<string> messages)
    {
        CommandType = commandType;
        Messages = messages;
    }
}