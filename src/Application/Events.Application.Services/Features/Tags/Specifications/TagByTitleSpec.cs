using Ardalis.Specification;
using Events.Domain.Aggregates.Events;

namespace Events.Application.Services.Features.Tags.Specifications;

public sealed class TagByTitleSpec : Specification<Tag>
{
    public TagByTitleSpec(string tagName)
    {
        Query.Where(tag => tag.Value.ToLower() == tagName.ToLower());
    }
}