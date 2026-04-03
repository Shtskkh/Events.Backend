using Ardalis.Specification;
using Ardalis.Specification.EntityFrameworkCore;
using Events.Application.Services.Features.Analytics.Repositories;
using Events.Domain.Exceptions;
using Events.Domain.Shared;
using Events.Domain.Shared.Entities.Analytics.Errors;
using Events.Domain.Shared.Entities.Analytics.PagesViews;
using Events.Infrastructure.Analytics.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Events.Infrastructure.Analytics.Context.PageViews.Repositories;

/// <inheritdoc />
public class PageViewRepository(IRepository<PageView, AnalyticsDbContext> repository) : IPageViewRepository
{
    /// <inheritdoc />
    public async Task<IReadOnlyCollection<PageView>> GetByFilterAsync(Specification<PageView> spec,
        CancellationToken ct)
    {
        var views = await repository.GetAllAsync()
            .WithSpecification(spec)
            .ToListAsync(ct);

        if (views.Count == 0)
            throw new NotFoundException(AnalyticsErrorMessages.PageViews.NotFoundAny);

        return views;
    }

    /// <inheritdoc />
    public async Task AddAsync(PageView view, CancellationToken ct)
    {
        await repository.AddAsync(view, ct);
    }
}