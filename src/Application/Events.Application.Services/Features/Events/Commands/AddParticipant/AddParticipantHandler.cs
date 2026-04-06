using Events.Application.Services.Features.Events.Repositories;
using Events.Application.Services.Features.Users.Repositories;
using Events.Application.Services.Features.Users.Specifications;
using MediatR;

namespace Events.Application.Services.Features.Events.Commands.AddParticipant;

/// <inheritdoc />
public sealed class AddParticipantHandler(IEventRepository eventRepository, IUserRepository userRepository)
    : IRequestHandler<AddParticipantCommand>
{
    /// <inheritdoc />
    public async Task Handle(AddParticipantCommand request, CancellationToken cancellationToken)
    {
        var spec = new UserSpec().WithId(request.UserId).AsNoTracking();
        await userRepository.GetAsync(spec, cancellationToken);

        const bool includeParticipants = true;
        var @event = await eventRepository.GetByIdAsync(request.EventId, cancellationToken, includeParticipants);

        @event.AddParticipant(request.UserId);
        await eventRepository.UpdateAsync(@event, cancellationToken);
    }
}