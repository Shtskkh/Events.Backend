namespace Events.Contracts.Errors;

/// <summary>
///     Модель ошибки.
/// </summary>
public sealed record ErrorDto
{
    /// <summary>
    ///     Статус код ошибки.
    /// </summary>
    public int StatusCode { get; init; }

    /// <summary>
    ///     Текст ошибки.
    /// </summary>
    public string? Message { get; init; }

    /// <summary>
    ///     Trace ID запроса.
    /// </summary>
    public string? TraceId { get; init; }
}