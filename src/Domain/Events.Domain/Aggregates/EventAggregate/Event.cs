using Events.Domain.Aggregates.EventAggregate.ValueObjects;
using Events.Domain.Shared;

namespace Events.Domain.Aggregates.EventAggregate;

public class Event : Entity<Guid>
{
    public Event(Guid id, string title) : base(id)
    {
        Title = new EventTitle(title);
    }

    public EventTitle Title { get; private set; }
}