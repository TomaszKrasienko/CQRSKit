using CQRSKit.Commands.Abstractions;
using CQRSKit.Dispatchers.Abstractions;
using CQRSKit.Queries.Abstractions;
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

    public async Task<TResult> HandleAsync<TResult>(IQuery<TResult> query, CancellationToken cancellationToken = default)
    {
        using var scope = serviceProvider.CreateScope();
        var handlerType = typeof(IQueryHandler<,>).MakeGenericType(query.GetType(), typeof(TResult));
        var handler = scope.ServiceProvider.GetRequiredService(handlerType);
        return await (Task<TResult>)handlerType
            .GetMethod(nameof(IQueryHandler<IQuery<TResult>, TResult>.HandleAsync))?
            .Invoke(handler, new object[] { query, cancellationToken })!;
    }
}