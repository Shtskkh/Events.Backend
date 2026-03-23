using Ardalis.Specification;
using Events.Domain.Shared.Entities.Analytics;
using Events.Domain.Shared.Entities.Analytics.PagesViews;

namespace Events.Application.Services.Features.Events.Specifications;

public class EventViewsSpec : Specification<PageView>
{
    public EventViewsSpec(Guid eventId)
    {
        Query.Where(e => e.EntityType == EntityTypes.Event);
        Query.Where(e => e.EntityId == eventId);
        Query.OrderBy(e => e.ViewedAt);
    }
}