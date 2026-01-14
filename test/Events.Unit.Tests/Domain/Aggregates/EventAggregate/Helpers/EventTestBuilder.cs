using Events.Domain.Aggregates.EventAggregate;
using Events.Domain.Aggregates.EventAggregate.ValueObjects;

namespace Events.Unit.Tests.Domain.Aggregates.EventAggregate.Helpers;

public class EventTestBuilder
{
    private readonly Guid _id = Guid.NewGuid();
    private EventTitle _title = new("Test title");

    public Event Build()
    {
        return new Event(
            _id,
            _title
        );
    }

    public EventTestBuilder WithTitle(string title)
    {
        _title = new EventTitle(title);
        return this;
    }
}