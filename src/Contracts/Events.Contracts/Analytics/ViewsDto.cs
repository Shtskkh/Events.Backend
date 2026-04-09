namespace Events.Contracts.Analytics;

/// <summary>
///     Модель посещаемости по дням.
/// </summary>
public sealed record ViewsDto
{
    /// <summary>
    ///     Дата.
    /// </summary>
    public DateOnly Date { get; init; }

    /// <summary>
    ///     Количество посещений.
    /// </summary>
    public long Views { get; init; }
}