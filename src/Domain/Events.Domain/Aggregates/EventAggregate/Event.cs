using Events.Domain.Aggregates.EventAggregate.ValueObjects;
using Events.Domain.Shared;

namespace Events.Domain.Aggregates.EventAggregate;

public class Event : Entity<Guid>
{
    public Event(Guid id, EventTitle title) : base(id)
    {
        Title = title;
    }

    public EventTitle Title { get; private set; }

    public void ChangeTitle(string title)
    {
        Title = new EventTitle(title);
    }
}