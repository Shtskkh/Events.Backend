namespace Events.Contracts.Events.EventsTypes;

/// <summary>
///     Модель аналитики типов мероприятий.
/// </summary>
public sealed record EventTypeAnalytics
{
    /// <summary>
    ///     Тип.
    /// </summary>
    public string Type { get; init; } = null!;

    /// <summary>
    ///     Количество.
    /// </summary>
    public int Count { get; init; }
}