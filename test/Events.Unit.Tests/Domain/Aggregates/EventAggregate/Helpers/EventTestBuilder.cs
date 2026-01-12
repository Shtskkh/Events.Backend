using Events.Domain.Aggregates.EventAggregate;

namespace Events.Unit.Tests.Domain.Aggregates.EventAggregate.Helpers;

public class EventTestBuilder
{
    private readonly Guid _id = Guid.NewGuid();
    private string _title = "Test title";

    public Event Build()
    {
        return new Event(
            _id,
            _title
        );
    }

    public EventTestBuilder WithTitle(string title)
    {
        _title = title;
        return this;
    }
}