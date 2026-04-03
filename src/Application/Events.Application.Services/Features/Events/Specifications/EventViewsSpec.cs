using Ardalis.Specification;
using Events.Domain.Aggregates.AnalyticsAggregate;

namespace Events.Application.Services.Features.Events.Specifications;

/// <summary>
///     Спецификация просмотров мероприятия.
/// </summary>
public class EventViewsSpec : Specification<PageView>
{
    public EventViewsSpec(Guid eventId)
    {
        Query.Where(e => e.EntityType == EntityTypes.Event);
        Query.Where(e => e.EntityId == eventId);
        Query.OrderBy(e => e.ViewedAt);
        Query.AsNoTracking();
    }
}