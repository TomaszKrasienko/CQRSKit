using System.Formats.Asn1;
using CQRSKit.Commands.Abstractions;
using CQRSKit.FluentValidation.Configuration;
using CQRSKit.FluentValidation.Exceptions;
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

        await handler.HandleAsync(command, cancellationToken);
    }
}