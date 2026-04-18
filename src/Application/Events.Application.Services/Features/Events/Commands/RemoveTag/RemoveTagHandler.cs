using Events.Application.Services.Features.Events.Repositories;
using Events.Application.Services.Features.Events.Specifications;
using Events.Domain.Aggregates.Events.Errors;
using Events.Domain.Exceptions;
using MediatR;

namespace Events.Application.Services.Features.Events.Commands.RemoveTag;

public sealed class RemoveTagHandler(IEventRepository eventRepository) : IRequestHandler<RemoveTagCommand>
{
    public async Task Handle(RemoveTagCommand request, CancellationToken ct)
    {
        var eventByIdSpec = new EventByIdSpec(request.EventId).IncludeTags();
        var @event = await eventRepository.FirstOrDefaultAsync(eventByIdSpec, ct);
        if (@event == null)
            throw new NotFoundException(EventErrors.NotFoundById(request.EventId));

        @event.RemoveTag(request.TagId);
        await eventRepository.UpdateAsync(@event, ct);
    }
}