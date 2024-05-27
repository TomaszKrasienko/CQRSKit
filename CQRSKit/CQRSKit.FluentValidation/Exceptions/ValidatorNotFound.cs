namespace CQRSKit.FluentValidation.Exceptions;

public sealed class ValidatorNotFound(Type TCommand)
    : Exception($"Validator for {TCommand} does not exist");