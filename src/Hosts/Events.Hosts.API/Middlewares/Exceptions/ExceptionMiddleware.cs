using System.Text.Json;
using Events.Application.Services.Exceptions;
using Events.Contracts.Errors;
using Events.Domain.Exceptions;

namespace Events.Hosts.API.Middlewares.Exceptions;

/// <summary>
///     Middleware для обработки ошибок слоёв.
/// </summary>
/// <param name="next">Следующий middleware в конвейере.</param>
/// <param name="logger">Логгер.</param>
public class ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger)
{
    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await next(context);
        }
        catch (Exception e)
        {
            await HandleExceptionAsync(context, e);
        }
    }

    private Task HandleExceptionAsync(HttpContext context, Exception exception)
    {
        logger.LogError("Ошибка: {exception.Message}", exception.Message);

        var errorDto = MapError(context, exception);
        context.Response.ContentType = "application/problem+json";
        context.Response.StatusCode = errorDto.StatusCode;

        return context.Response.WriteAsync(JsonSerializer.Serialize(errorDto));
    }

    private static ErrorDto MapError(HttpContext context, Exception exception)
    {
        return exception switch
        {
            DomainException => new ErrorDto
            {
                StatusCode = StatusCodes.Status400BadRequest,
                Message = exception.Message,
                TraceID = context.TraceIdentifier
            },

            NotFoundException => new ErrorDto
            {
                StatusCode = StatusCodes.Status404NotFound,
                Message = exception.Message,
                TraceID = context.TraceIdentifier
            },

            HttpRequestException => new ErrorDto
            {
                StatusCode = StatusCodes.Status503ServiceUnavailable,
                Message = "Запрашиваемый сервис недоступен. Попробуйте позже.",
                TraceID = context.TraceIdentifier
            },

            UnauthorizedException => new ErrorDto
            {
                StatusCode = StatusCodes.Status401Unauthorized,
                Message = exception.Message,
                TraceID = context.TraceIdentifier
            },

            _ => new ErrorDto
            {
                StatusCode = StatusCodes.Status500InternalServerError,
                Message = "Неожиданная ошибка сервера.",
                TraceID = context.TraceIdentifier
            }
        };
    }
}