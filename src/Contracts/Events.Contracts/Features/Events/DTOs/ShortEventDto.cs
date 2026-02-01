namespace Events.Contracts.Features.Events.DTOs;

/// <summary>
///     Краткая информация о мероприятии.
/// </summary>
public class ShortEventDto
{
    /// <summary>
    ///     Название мероприятия.
    /// </summary>
    public string Title { get; init; } = null!;

    /// <summary>
    ///     Анонс (краткое описание) мероприятия.
    /// </summary>
    public string Announcement { get; init; } = null!;

    /// <summary>
    ///     Дата и время начала мероприятия.
    /// </summary>
    public DateTimeOffset StartDateTime { get; init; }

    /// <summary>
    ///     Дата и время окончания мероприятия.
    /// </summary>
    public DateTimeOffset EndDateTime { get; init; }
}