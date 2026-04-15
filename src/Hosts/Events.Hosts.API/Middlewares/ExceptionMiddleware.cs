using System.Text.Json;
using Events.Application.Services.Exceptions;
using Events.Contracts.Errors;
using Events.Domain.Exceptions;

namespace Events.Hosts.API.Middlewares;

/// <summary>
///     Middleware для обработки ошибок слоёв.
/// </summary>
/// <param name="logger">Логгер.</param>
public class ExceptionMiddleware(ILogger<ExceptionMiddleware> logger) : IMiddleware
{
    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
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
            DomainException domainException => new ErrorDto
            {
                StatusCode = StatusCodes.Status422UnprocessableEntity,
                ErrorCode = domainException.Error.ErrorCode,
                Message = domainException.Error.ErrorMessage,
                TraceId = context.TraceIdentifier
            },

            NotFoundException notFoundException => new ErrorDto
            {
                StatusCode = StatusCodes.Status404NotFound,
                ErrorCode = notFoundException.Error.ErrorCode,
                Message = notFoundException.Error.ErrorMessage,
                TraceId = context.TraceIdentifier
            },

            HttpRequestException => new ErrorDto
            {
                StatusCode = StatusCodes.Status503ServiceUnavailable,
                Message = "Запрашиваемый сервис недоступен. Попробуйте позже.",
                TraceId = context.TraceIdentifier
            },

            UnauthorizedException unauthorizedException => new ErrorDto
            {
                StatusCode = StatusCodes.Status401Unauthorized,
                ErrorCode = unauthorizedException.Error.ErrorCode,
                Message = unauthorizedException.Error.ErrorMessage,
                TraceId = context.TraceIdentifier
            },

            _ => new ErrorDto
            {
                StatusCode = StatusCodes.Status500InternalServerError,
                ErrorCode = "Неизвестная ошибка.",
                Message = "Неожиданная ошибка сервера.",
                TraceId = context.TraceIdentifier
            }
        };
    }
}