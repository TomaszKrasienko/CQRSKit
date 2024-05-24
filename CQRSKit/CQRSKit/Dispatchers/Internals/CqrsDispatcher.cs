using CQRSKit.Commands.Abstractions;
using CQRSKit.Dispatchers.Abstractions;
using Microsoft.Extensions.DependencyInjection;

namespace CQRSKit.Dispatchers.Internals;

internal sealed class CqrsDispatcher(
    IServiceProvider serviceProvider) : ICqrsDispatcher
{
    public async Task HandleAsync<TCommand>(TCommand command, CancellationToken cancellationToken = default) 
        where TCommand : class, ICommand
    {
        using var scope = serviceProvider.CreateScope();
        var handler = scope.ServiceProvider.GetRequiredService<ICommandHandler<TCommand>>();
        await handler.HandleAsync(command, cancellationToken);
    }
}