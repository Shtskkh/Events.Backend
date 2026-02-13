namespace Events.Contracts.Features.EventsTypes;

/// <summary>
///     Информация о типе мероприятия.
/// </summary>
public class EventTypeDto
{
    /// <summary>
    ///     Идентификатор типа мероприятия.
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    ///     Название типа мероприятия.
    /// </summary>
    public string Title { get; set; } = null!;
}