using CQRSKit.Commands.Abstractions;

namespace CQRSKit.Dispatchers.Abstractions;

public interface ICqrsDispatcher
{
    Task HandleAsync<TCommand>(TCommand command, CancellationToken cancellationToken = default) 
        where TCommand : class, ICommand;
}