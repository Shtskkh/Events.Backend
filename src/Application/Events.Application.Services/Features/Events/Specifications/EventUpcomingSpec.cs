using Ardalis.Specification;
using Events.Domain.Aggregates.Events;

namespace Events.Application.Services.Features.Events.Specifications;

public sealed class EventUpcomingSpec : Specification<Event>
{
    public EventUpcomingSpec(DateTimeOffset utcNow)
    {
        Query.Where(e => e.DateTimeRange.StartDateTime > utcNow);
    }
}