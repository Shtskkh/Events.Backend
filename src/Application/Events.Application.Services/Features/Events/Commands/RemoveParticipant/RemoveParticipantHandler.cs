using Events.Application.Services.Features.Events.Repositories;
using MediatR;

namespace Events.Application.Services.Features.Events.Commands.RemoveParticipant;

/// <inheritdoc />
public class RemoveParticipantHandler(IEventRepository eventRepository) : IRequestHandler<RemoveParticipantCommand>
{
    /// <inheritdoc />
    public async Task Handle(RemoveParticipantCommand request, CancellationToken cancellationToken)
    {
        const bool includeParticipants = true;
        var @event = await eventRepository.GetByIdAsync(request.EventId, cancellationToken, includeParticipants);

        @event.RemoveParticipant(request.ParticipantId);

        await eventRepository.UpdateAsync(@event, cancellationToken);
    }
}