namespace CQRSKit.Exceptions;

public abstract class CqrsKitException(string message)
    : Exception(message);