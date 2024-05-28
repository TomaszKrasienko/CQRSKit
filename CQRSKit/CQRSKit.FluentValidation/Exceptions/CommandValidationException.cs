using CQRSKit.Exceptions;
using CQRSKit.FluentValidation.Types;

namespace CQRSKit.FluentValidation.Exceptions;

public sealed class CommandValidationException(ValidationErrorDto errorDto)
    : CqrsKitException($"Invalid command with type {errorDto.CommandType}")
{
    public ValidationErrorDto ErrorDto { get; set; } = errorDto;
}