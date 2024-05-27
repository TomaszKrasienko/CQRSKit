using System.Formats.Asn1;
using CQRSKit.Commands.Abstractions;
using CQRSKit.FluentValidation.Configuration;
using CQRSKit.FluentValidation.Exceptions;
using CQRSKit.FluentValidation.Types;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace CQRSKit.FluentValidation.Decorators;

internal sealed class FluentValidationCommandHandlerDecorator<TCommand>(
    ICommandHandler<TCommand> handler,
    IServiceProvider serviceProvider,
    CqrsKitFluentValidationBuilder builder) : ICommandHandler<TCommand> where TCommand : ICommand
{
    public async Task HandleAsync(TCommand command, CancellationToken cancellationToken = default)
    { 
        using var scope = serviceProvider.CreateScope(); 
        var validator = scope.ServiceProvider.GetService<IValidator<TCommand>>();

        if (builder.AllCommands && validator is null)
        {
            throw new ValidatorNotFound(typeof(TCommand));
        }

        if (validator is not null)
        {
            var result = await validator.ValidateAsync(command, cancellationToken);
            if (!result.IsValid)
            {
                var errorResult = new ValidationErrorDto(
                    typeof(TCommand),
                    result.Errors.Select(x => x.ErrorMessage).ToList());

                throw new CommandValidationException(errorResult);
            }

        }

        await handler.HandleAsync(command, cancellationToken);
    }
}