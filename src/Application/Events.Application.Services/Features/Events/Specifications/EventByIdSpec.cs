using Ardalis.Specification;
using Events.Domain.Aggregates.Events;

namespace Events.Application.Services.Features.Events.Specifications;

public sealed class EventByIdSpec : Specification<Event>
{
    public EventByIdSpec(Guid eventId)
    {
        Query.Where(e => e.Id == eventId);
    }

    public EventByIdSpec IncludeParticipants()
    {
        Query.Include(e => e.Participants);
        return this;
    }

    public new EventByIdSpec AsNoTracking()
    {
        Query.AsNoTracking();
        return this;
    }
}