using Events.Application.Services.Features.Events.Repositories;
using Events.Application.Services.Features.Users.Specifications;
using Events.Application.Services.Shared;
using Events.Domain.Aggregates.UserAggregate;
using MediatR;

namespace Events.Application.Services.Features.Events.Commands.AddParticipant;

/// <inheritdoc />
public sealed class AddParticipantHandler(IEventRepository eventRepository, IRepository<User> userRepository)
    : IRequestHandler<AddParticipantCommand>
{
    /// <inheritdoc />
    public async Task Handle(AddParticipantCommand request, CancellationToken cancellationToken)
    {
        var spec = new UserSpec().WithId(request.UserId).AsNoTracking();
        await userRepository.AnyAsync(spec, cancellationToken);

        var @event = await eventRepository.GetByIdAsync(request.EventId, cancellationToken);

        @event.AddParticipant(request.UserId);

        await eventRepository.UpdateAsync(@event, cancellationToken);
    }
}