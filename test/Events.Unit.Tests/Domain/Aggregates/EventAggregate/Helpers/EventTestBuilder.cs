using Events.Domain.Aggregates.EventAggregate;
using Events.Domain.Aggregates.EventAggregate.ValueObjects;

namespace Events.Unit.Tests.Domain.Aggregates.EventAggregate.Helpers;

public class EventTestBuilder
{
    private readonly Guid _id = Guid.NewGuid();
    private readonly bool _needRegistration = false;
    private EventAnnouncement _announcement = new("Test announcement");
    private EventDescription _description = new("Test description");
    private DateTimeOffset _endDateTime = DateTimeOffset.Now + TimeSpan.FromDays(7);
    private EventType _eventType = EventType.Conference;
    private DateTimeOffset _startDateTime = DateTimeOffset.Now;
    private EventTitle _title = new("Test title");

    public Event Build()
    {
        return new Event(
            _id,
            _title,
            _announcement,
            _description,
            _endDateTime,
            _startDateTime,
            _eventType,
            _needRegistration
        );
    }

    public EventTestBuilder WithTitle(string title)
    {
        _title = new EventTitle(title);
        return this;
    }

    public EventTestBuilder WithAnnouncement(string announcement)
    {
        _announcement = new EventAnnouncement(announcement);
        return this;
    }

    public EventTestBuilder WithDescription(string description)
    {
        _description = new EventDescription(description);
        return this;
    }

    public EventTestBuilder WithStartDateTime(DateTimeOffset startDateTime)
    {
        _startDateTime = startDateTime;
        return this;
    }

    public EventTestBuilder WithEndDateTime(DateTimeOffset endDateTime)
    {
        _endDateTime = endDateTime;
        return this;
    }

    public EventTestBuilder WithEventType(EventType eventType)
    {
        _eventType = eventType;
        return this;
    }
}