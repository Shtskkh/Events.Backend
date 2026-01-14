using Events.Domain.Aggregates.EventAggregate;
using Events.Domain.Aggregates.EventAggregate.ValueObjects;

namespace Events.Unit.Tests.Domain.Aggregates.EventAggregate.Helpers;

public class EventTestBuilder
{
    private readonly Guid _id = Guid.NewGuid();
    private EventAnnouncement _announcement = new("Test announcement");
    private EventTitle _title = new("Test title");

    public Event Build()
    {
        return new Event(
            _id,
            _title,
            _announcement
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
}