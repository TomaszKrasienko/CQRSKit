namespace CQRSKit.Exceptions;

public sealed class CqrsKitException(string message)
    : Exception(message);