namespace Events.Contracts.Features.Events.DTOs;

/// <summary>
///     Полная информация о мероприятии.
/// </summary>
public class EventDto
{
    /// <summary>
    ///     Название мероприятия.
    /// </summary>
    public required string Title { get; set; }

    /// <summary>
    ///     Описание мероприятия.
    /// </summary>
    public required string Description { get; set; }
}