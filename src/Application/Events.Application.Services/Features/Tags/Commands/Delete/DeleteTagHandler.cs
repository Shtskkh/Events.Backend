using Events.Application.Services.Shared;
using Events.Domain.Aggregates.Events;
using Events.Domain.Aggregates.Events.Errors;
using Events.Domain.Exceptions;
using MediatR;

namespace Events.Application.Services.Features.Tags.Commands.Delete;

public sealed class DeleteTagHandler(IRepository<Tag> tagRepository) : IRequestHandler<DeleteTagCommand>
{
    public async Task Handle(DeleteTagCommand request, CancellationToken cancellationToken)
    {
        var tag = await tagRepository.GetByIdAsync(request.TagId, cancellationToken);
        if (tag == null)
            throw new NotFoundException(TagErrors.NotFoundById(request.TagId));

        await tagRepository.DeleteAsync(tag, cancellationToken);
    }
}