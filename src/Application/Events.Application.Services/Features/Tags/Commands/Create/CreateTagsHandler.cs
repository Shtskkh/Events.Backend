using Events.Application.Services.Features.Tags.Specifications;
using Events.Application.Services.Shared;
using Events.Domain.Aggregates.Events.Errors;
using Events.Domain.Exceptions;
using MediatR;
using Tag = Events.Domain.Aggregates.Events.Tag;

namespace Events.Application.Services.Features.Tags.Commands.Create;

public sealed class CreateTagsHandler(IRepository<Tag> tagRepository)
    : IRequestHandler<CreateTagsCommand, IReadOnlyCollection<int>>
{
    public async Task<IReadOnlyCollection<int>> Handle(CreateTagsCommand request, CancellationToken cancellationToken)
    {
        foreach (var tag in request.Tags)
        {
            var tagByTitleSpec = new TagByTitleSpec(tag);
            var tagExists = await tagRepository.AnyAsync(tagByTitleSpec, cancellationToken);

            if (tagExists)
                throw new DomainException(TagErrors.TagAlreadyExists(tag));
        }

        var ids = new List<int>(request.Tags.Count);
        foreach (var tag in request.Tags)
        {
            var tagEntity = new Tag(0, tag);
            await tagRepository.AddAsync(tagEntity, cancellationToken);

            ids.Add(tagEntity.Id);
        }

        return ids;
    }
}