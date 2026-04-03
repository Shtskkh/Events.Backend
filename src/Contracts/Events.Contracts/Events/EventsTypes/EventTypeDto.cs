namespace Events.Contracts.Events.EventsTypes;

/// <summary>
///     Информация о типе мероприятия.
/// </summary>
public class EventTypeDto
{
    /// <summary>
    ///     Идентификатор типа мероприятия.
    /// </summary>
    public int Id { get; init; }

    /// <summary>
    ///     Название типа мероприятия.
    /// </summary>
    public string Title { get; init; } = null!;
}