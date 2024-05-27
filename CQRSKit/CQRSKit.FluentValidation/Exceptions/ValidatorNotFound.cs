namespace CQRSKit.FluentValidation.Exceptions;

public sealed class ValidatorNotFound(Type typeCommand)
    : Exception($"Validator for {typeCommand} does not exist");