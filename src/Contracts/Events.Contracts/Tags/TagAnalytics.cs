namespace Events.Contracts.Tags;

/// <summary>
///     Модель аналитики тэгов.
/// </summary>
public sealed record TagAnalytics
{
    /// <summary>
    ///     Тэг.
    /// </summary>
    public string Tag { get; init; } = null!;

    /// <summary>
    ///     Количество использований.
    /// </summary>
    public int Count { get; init; }
}