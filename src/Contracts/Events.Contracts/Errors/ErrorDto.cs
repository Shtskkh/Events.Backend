namespace Events.Contracts.Errors;

/// <summary>
///     Модель ошибки.
/// </summary>
public class ErrorDto
{
    /// <summary>
    ///     Статус код ошибки.
    /// </summary>
    public int StatusCode { get; set; }

    /// <summary>
    ///     Текст ошибки.
    /// </summary>
    public string Message { get; set; }

    /// <summary>
    ///     Trace ID запроса.
    /// </summary>
    public string TraceID { get; set; }
}