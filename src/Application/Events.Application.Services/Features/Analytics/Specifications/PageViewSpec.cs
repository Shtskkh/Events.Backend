using Ardalis.Specification;
using Events.Domain.Aggregates.Analytics;

namespace Events.Application.Services.Features.Analytics.Specifications;

/// <summary>
///     Базовая спецификация просмотров.
/// </summary>
public class PageViewSpec : Specification<PageView>
{
    public PageViewSpec WithEntityType(string entityType)
    {
        Query.Where(pv => pv.EntityType == entityType);
        return this;
    }

    public PageViewSpec WithEntityId(Guid entityId)
    {
        Query.Where(pv => pv.EntityId == entityId);
        return this;
    }

    public PageViewSpec WithUserId(Guid userId)
    {
        Query.Where(pv => pv.UserId == userId);
        return this;
    }

    public PageViewSpec ViewedAfter(DateTime viewedAfter)
    {
        Query.Where(pv => pv.ViewedAt >= viewedAfter);
        return this;
    }

    public PageViewSpec ViewedBefore(DateTime viewedBefore)
    {
        Query.Where(pv => pv.ViewedAt <= viewedBefore);
        return this;
    }

    public new PageViewSpec AsNoTracking()
    {
        Query.AsNoTracking();
        return this;
    }
}