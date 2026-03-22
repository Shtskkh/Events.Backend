using Ardalis.Specification;
using Events.Domain.Aggregates.EventAggregate;

namespace Events.Application.Services.Features.Events.Specifications;

/// <summary>
///     Получить коллекцию мероприятий по их ID.
/// </summary>
public class EventsByIdsSpec : Specification<Event>
{
    public EventsByIdsSpec(IEnumerable<Guid> eventIds)
    {
        Query.Where(u => eventIds.Contains(u.Id));
        Query.AsTracking();
    }
}