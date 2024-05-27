using CQRSKit.Exceptions;

namespace CQRSKit.FluentValidation.Exceptions;

public sealed class ValidatorNotFound(Type typeCommand)
    : CqrsKitException($"Validator for {typeCommand} does not exist");