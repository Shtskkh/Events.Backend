namespace Events.Contracts.Events.EventsFormats;

/// <summary>
///     Модель аналитики форматов мероприятий.
/// </summary>
public sealed record EventFormatAnalyticsDto
{
    /// <summary>
    ///     Формат.
    /// </summary>
    public string Format { get; init; } = null!;

    /// <summary>
    ///     Количество.
    /// </summary>
    public int Count { get; init; }
}