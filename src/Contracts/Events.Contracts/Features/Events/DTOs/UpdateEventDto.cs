namespace Events.Contracts.Features.Events.DTOs;

/// <summary>
///     Модель обновления мероприятия.
/// </summary>
public record UpdateEventDto
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
}