using CQRSKit.Queries.Abstractions;
using Microsoft.Extensions.Logging;

namespace CQRSKit.Logging;

internal sealed class QueryHandlerLogDecorator<TQuery, TResult>(
    ILogger<IQueryHandler<TQuery, TResult>> logger,
    IQueryHandler<TQuery, TResult> handler) : IQueryHandler<TQuery, TResult>
    where TQuery : IQuery<TResult>
{
    public async Task<TResult> HandleAsync(TQuery query, CancellationToken cancellationToken = default)
    {
        logger.LogInformation($"Handling query: {typeof(TQuery)}");
        try
        {
            return await handler.HandleAsync(query, cancellationToken);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, ex.Message);
            throw;
        }
    }
}