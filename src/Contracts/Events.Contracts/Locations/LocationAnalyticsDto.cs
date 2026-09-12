namespace Events.Contracts.Locations;

/// <summary>
///     Модель аналитики локаций.
/// </summary>
public sealed record LocationAnalyticsDto
{
    /// <summary>
    ///     Название локации.
    /// </summary>
    public string Title { get; init; }

    /// <summary>
    ///     Количество мероприятий.
    /// </summary>
    public int Count { get; init; }
}