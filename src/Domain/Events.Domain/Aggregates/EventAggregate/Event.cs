using Events.Domain.Shared;

namespace Events.Domain.Aggregates.EventAggregate;

public class Event : Entity<Guid>
{
    public Event(Guid id) : base(id)
    {
    }
}