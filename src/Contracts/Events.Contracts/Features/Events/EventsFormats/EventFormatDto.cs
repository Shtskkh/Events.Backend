namespace Events.Contracts.Features.Events.EventsFormats;

/// <summary>
///     Информация о формате мероприятия.
/// </summary>
public class EventFormatDto
{
    /// <summary>
    ///     Идентификатор.
    /// </summary>
    public int Id { get; init; }

    /// <summary>
    ///     Название.
    /// </summary>
    public string Title { get; init; } = null!;
}