namespace Events.Contracts.Features.Events.DTOs;

/// <summary>
///     Краткая информация о мероприятии.
/// </summary>
public class ShortEventDto
{
    /// <summary>
    ///     Название мероприятия.
    /// </summary>
    public required string Title { get; init; }

    /// <summary>
    ///     Анонс (краткое описание) мероприятия.
    /// </summary>
    public required string Announcement { get; init; }
}