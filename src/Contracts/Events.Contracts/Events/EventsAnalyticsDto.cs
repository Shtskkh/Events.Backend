namespace Events.Contracts.Events;

/// <summary>
///     Модель общей аналитики мероприятий.
/// </summary>
public record EventsAnalyticsDto
{
    /// <summary>
    ///     Общее количество мероприятий.
    /// </summary>
    public int TotalCount { get; init; }

    /// <summary>
    ///     Количество предстоящих.
    /// </summary>
    public int UpcomingCount { get; init; }

    /// <summary>
    ///     Количество завершённых.
    /// </summary>
    public int FinishedCount { get; init; }
}