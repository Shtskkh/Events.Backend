using AutoMapper;
using Events.Application.Services.Features.Tags.Specifications;
using Events.Application.Services.Shared;
using Events.Contracts.Tags;
using Events.Domain.Aggregates.Events;
using Events.Domain.Aggregates.Events.Errors;
using Events.Domain.Exceptions;
using MediatR;

namespace Events.Application.Services.Features.Tags.Queries;

public class GetTagsByFilterHandler(IRepository<Tag> tagRepository, IMapper mapper)
    : IRequestHandler<GetTagsByFilterQuery, IReadOnlyCollection<TagDto>>
{
    public async Task<IReadOnlyCollection<TagDto>> Handle(GetTagsByFilterQuery request,
        CancellationToken cancellationToken)
    {
        var tagsByFilterSpec = new TagFilterSpec(request.Filter);
        var tags = await tagRepository.ListAsync(tagsByFilterSpec, cancellationToken);

        if (tags.Count == 0)
            throw new NotFoundException(TagErrors.NotFoundByFilter);

        return mapper.Map<IReadOnlyCollection<TagDto>>(tags);
    }
}