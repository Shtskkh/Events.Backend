using Ardalis.Specification;
using Events.Domain.Shared.Entities.Analytics;
using Events.Domain.Shared.Entities.Analytics.PagesViews;

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