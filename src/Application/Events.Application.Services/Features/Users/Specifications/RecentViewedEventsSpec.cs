using Ardalis.Specification;
using Events.Domain.Aggregates.AnalyticsAggregate;

namespace Events.Application.Services.Features.Users.Specifications;

public class RecentViewedEventsSpec : Specification<PageView>
{
    public RecentViewedEventsSpec(Guid userId)
    {
        Query.Where(e => e.EntityType == EntityTypes.Event);
        Query.Where(e => e.UserId == userId);
        Query.OrderByDescending(e => e.ViewedAt);
        Query.AsTracking();
    }
}