using Ardalis.Specification;
using Events.Contracts.Tags;
using Events.Domain.Aggregates.Events;

namespace Events.Application.Services.Features.Tags.Specifications;

public sealed class TagFilterSpec : Specification<Tag>
{
    public TagFilterSpec(TagFilterDto filter)
    {
        if (!string.IsNullOrWhiteSpace(filter.TitleLike))
            Query.Where(t => t.Value.ToLower().Contains(filter.TitleLike.ToLower()));

        Query.Skip(filter.Size * (filter.Page - 1));
        Query.Take(filter.Size);

        Query.OrderByDescending(t => t.Id);
        Query.AsNoTracking();
    }
}