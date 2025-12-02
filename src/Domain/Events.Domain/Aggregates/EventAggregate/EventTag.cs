using Events.Domain.Entities;

namespace Events.Domain.Aggregates.EventAggregate;

/// <summary>
/// Тэг мероприятия.
/// </summary>
public class EventTag
{
    /// <summary>
    /// Id мероприятия.
    /// </summary>
    public Guid EventId { get; private set; }

    /// <summary>
    /// Id тэга.
    /// </summary>
    public int TagId { get; private set; }

    /// <summary>
    /// Мероприятие.
    /// </summary>
    public Event Event { get; private set; }

    /// <summary>
    /// Тэг.
    /// </summary>
    public Tag Tag { get; private set; }

    public EventTag(Guid eventId, int tagId)
    {
        EventId = eventId;
        TagId = tagId;
    }
}