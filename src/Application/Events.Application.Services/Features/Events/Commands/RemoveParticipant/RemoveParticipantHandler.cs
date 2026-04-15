using Events.Application.Services.Features.Events.Repositories;
using Events.Domain.Aggregates.Events.Errors;
using Events.Domain.Exceptions;
using MediatR;

namespace Events.Application.Services.Features.Events.Commands.RemoveParticipant;

public sealed class RemoveParticipantHandler(IEventRepository eventRepository)
    : IRequestHandler<RemoveParticipantCommand>
{
    public async Task Handle(RemoveParticipantCommand request, CancellationToken cancellationToken)
    {
        var @event = await eventRepository.GetByIdAsync(request.EventId, cancellationToken);

        if (@event == null)
            throw new NotFoundException(EventErrors.NotFoundById(request.EventId));

        @event.RemoveParticipant(request.ParticipantId);

        await eventRepository.UpdateAsync(@event, cancellationToken);
    }
}