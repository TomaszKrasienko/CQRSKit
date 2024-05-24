using CQRSKit.Commands.Abstractions;
using Microsoft.Extensions.Logging;

namespace CQRSKit.Logging;

internal sealed class CommandHandlerLogDecorator<TCommand>(
    ILogger<ICommandHandler<TCommand>> logger,
    ICommandHandler<TCommand> handler) : ICommandHandler<TCommand> where TCommand : class, ICommand
{
    public async Task HandleAsync(TCommand command, CancellationToken cancellationToken = default)
    {
        logger.LogInformation($"Handling command: {command.GetType()}");
        try
        {
            await handler.HandleAsync(command, cancellationToken);
        }
        catch (Exception ex)
        {
            logger.LogInformation(ex, ex.Message);
        }
    }
}