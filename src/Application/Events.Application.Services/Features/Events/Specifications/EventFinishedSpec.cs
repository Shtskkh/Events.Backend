using Ardalis.Specification;
using Events.Domain.Aggregates.Events;

namespace Events.Application.Services.Features.Events.Specifications;

public sealed class EventFinishedSpec : Specification<Event>
{
    public EventFinishedSpec(DateTimeOffset utcNow)
    {
        Query.Where(e => e.DateTimeRange.EndDateTime <= utcNow);
    }
}