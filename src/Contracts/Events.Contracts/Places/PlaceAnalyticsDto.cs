namespace Events.Contracts.Places;

/// <summary>
///     Модель аналитики помещений.
/// </summary>
public sealed record PlaceAnalyticsDto
{
    /// <summary>
    ///     Название локации.
    /// </summary>
    public string Location { get; init; } = null!;

    /// <summary>
    ///     Номер помещен
    /// </summary>ия.
    public string Place { get; init; } = null!;

    /// <summary>
    ///     Количество использований.
    /// </summary>
    public int Count { get; init; }
}