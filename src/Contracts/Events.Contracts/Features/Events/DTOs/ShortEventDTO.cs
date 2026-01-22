namespace Events.Contracts.Features.Events.DTOs;

/// <summary>
///     Краткая информация о мероприятии.
/// </summary>
public class ShortEventDto
{
    /// <summary>
    ///     Название мероприятия.
    /// </summary>
    public required string Title { get; set; }

    /// <summary>
    ///     Анонс (краткое описание) мероприятия.
    /// </summary>
    public required string Announcement { get; set; }

    /// <summary>
    ///     Описание мероприятия.
    /// </summary>
    public required string Description { get; set; }
}