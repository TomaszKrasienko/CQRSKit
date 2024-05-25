using CQRSKit.Commands.Abstractions;
using CQRSKit.Queries.Abstractions;

namespace CQRSKit.Dispatchers.Abstractions;

public interface ICqrsDispatcher
{
    Task HandleAsync<TCommand>(TCommand command, CancellationToken cancellationToken = default) 
        where TCommand : class, ICommand;

    Task<TResult> HandleAsync<TResult>(IQuery<TResult> query, CancellationToken cancellationToken = default);
}