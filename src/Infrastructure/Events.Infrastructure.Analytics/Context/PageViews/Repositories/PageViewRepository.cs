using Events.Application.Services.Features.Analytics.Repositories;
using Events.Domain.Shared.Entities.Analytics.PagesViews;
using Events.Infrastructure.Analytics.Repositories;

namespace Events.Infrastructure.Analytics.Context.PageViews.Repositories;

/// <inheritdoc />
public class PageViewRepository(IRepository<PageView, AnalyticsDbContext> repository) : IPageViewRepository
{
    /// <inheritdoc />
    public async Task AddAsync(PageView view, CancellationToken ct)
    {
        await repository.AddAsync(view, ct);
    }
}