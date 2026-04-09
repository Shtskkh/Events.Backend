namespace Events.Contracts.Events;

/// <summary>
///     Модель обновления мероприятия.
/// </summary>
public sealed record UpdateEventDto
{
    /// <summary>
    ///     Название.
    /// </summary>
    public string? Title { get; init; }

    /// <summary>
    ///     Анонс.
    /// </summary>
    public string? Announcement { get; init; }

    /// <summary>
    ///     Описание.
    /// </summary>
    public string? Description { get; init; }

    /// <summary>
    ///     Дата и время начала.
    /// </summary>
    public DateTimeOffset? StartDateTime { get; init; }

    /// <summary>
    ///     Дата и время окончания.
    /// </summary>
    public DateTimeOffset? EndDateTime { get; init; }
}