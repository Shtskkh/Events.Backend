using Events.Domain.Aggregates.EventAggregate.ValueObjects;

namespace Events.Domain.Aggregates.EventAggregate.Factories;

/// <inheritdoc />
public class EventFactory : IEventFactory
{
    /// <inheritdoc />
    public Event Create(string title, string announcement, string description, DateTimeOffset startDateTime,
        DateTimeOffset endDateTime, EventType eventType, EventFormat eventFormat, bool needRegistration,
        Guid? previewFilename = null, string? placeholderFilename = null)
    {
        var id = Guid.NewGuid();
        var titleVo = new EventTitle(title);
        var announcementVo = new EventAnnouncement(announcement);
        var descriptionVo = new EventDescription(description);

        return new Event(
            id,
            titleVo,
            announcementVo,
            descriptionVo,
            startDateTime,
            endDateTime,
            eventType,
            eventFormat,
            needRegistration,
            previewFilename,
            placeholderFilename
        );
    }
}