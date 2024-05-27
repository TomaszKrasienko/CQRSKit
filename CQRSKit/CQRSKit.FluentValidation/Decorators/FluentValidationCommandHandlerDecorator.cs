using CQRSKit.Commands.Abstractions;

namespace CQRSKit.FluentValidation.Decorators;

internal sealed class FluentValidationCommandHandlerDecorator<TCommand>(
    ICommandHandler<TCommand> handler,
    IServiceProvider serviceProvider) : ICommandHandler<TCommand> where TCommand : ICommand
{
    public Task HandleAsync(TCommand command, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }
}