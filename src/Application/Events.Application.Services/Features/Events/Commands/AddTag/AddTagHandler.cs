using Events.Application.Services.Features.Events.Repositories;
using Events.Application.Services.Features.Events.Specifications;
using Events.Application.Services.Shared;
using Events.Domain.Aggregates.Events;
using Events.Domain.Aggregates.Events.Errors;
using Events.Domain.Exceptions;
using MediatR;

namespace Events.Application.Services.Features.Events.Commands.AddTag;

public sealed class AddTagHandler(IEventRepository eventRepository, IRepository<Tag> tagRepository)
    : IRequestHandler<AddTagCommand>
{
    public async Task Handle(AddTagCommand request, CancellationToken ct)
    {
        var eventByIdSpec = new EventByIdSpec(request.EventId).IncludeTags();
        var @event = await eventRepository.FirstOrDefaultAsync(eventByIdSpec, ct);
        if (@event == null)
            throw new NotFoundException(EventErrors.NotFoundById(request.EventId));

        var tag = await tagRepository.GetByIdAsync(request.TagId, ct);
        if (tag == null)
            throw new NotFoundException(TagErrors.NotFoundById(request.TagId));

        @event.AddTag(tag);
        await eventRepository.UpdateAsync(@event, ct);
    }
}