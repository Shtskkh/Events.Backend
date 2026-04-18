using Events.Application.Services.Features.Tags.Specifications;
using Events.Application.Services.Shared;
using Events.Domain.Aggregates.Events.Errors;
using Events.Domain.Exceptions;
using MediatR;
using Tag = Events.Domain.Aggregates.Events.Tag;

namespace Events.Application.Services.Features.Tags.Commands.Create;

public sealed class CreateTagsHandler(IRepository<Tag> tagRepository)
    : IRequestHandler<CreateTagCommand, int>
{
    public async Task<int> Handle(CreateTagCommand request, CancellationToken cancellationToken)
    {
        var tagByTitleSpec = new TagByTitleSpec(request.Tag);
        var tagExists = await tagRepository.AnyAsync(tagByTitleSpec, cancellationToken);

        if (tagExists)
            throw new DomainException(TagErrors.TagAlreadyExists(request.Tag));

        var tag = new Tag(default, request.Tag);
        await tagRepository.AddAsync(tag, cancellationToken);

        return tag.Id;
    }
}