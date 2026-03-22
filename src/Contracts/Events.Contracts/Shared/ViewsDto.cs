namespace Events.Contracts.Shared;

/// <summary>
///     Модель посещаемости по дням.
/// </summary>
public record ViewsDto
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