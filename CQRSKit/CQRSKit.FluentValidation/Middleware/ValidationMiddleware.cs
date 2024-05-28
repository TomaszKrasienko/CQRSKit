using CQRSKit.FluentValidation.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace CQRSKit.FluentValidation.Middleware;

internal sealed class ValidationMiddleware(
    ILogger<ValidationMiddleware> logger) : IMiddleware
{
    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        try
        {
            await next(context);
        }
        catch (CommandValidationException validationException)
        {
            logger.LogError(validationException, validationException.Message);
            context.Response.StatusCode = StatusCodes.Status422UnprocessableEntity;
            await context.Response.WriteAsJsonAsync(validationException.ErrorDto);
        }
    }
}