using Ardalis.Specification;
using Events.Domain.Aggregates.Events;

namespace Events.Application.Services.Features.Events.Specifications;

public class EventsByIdsSpec : Specification<Event>
{
    public EventsByIdsSpec(IEnumerable<Guid> eventIds)
    {
        Query.Where(e => eventIds.Contains(e.Id));
    }

    public new EventsByIdsSpec AsNoTracking()
    {
        Query.AsNoTracking();
        return this;
    }
}