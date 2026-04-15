using Events.Application.Services.Features.Events.Repositories;
using Events.Application.Services.Features.Users.Specifications;
using Events.Application.Services.Shared;
using Events.Domain.Aggregates.Events.Errors;
using Events.Domain.Aggregates.Users;
using Events.Domain.Aggregates.Users.Errors;
using Events.Domain.Exceptions;
using MediatR;

namespace Events.Application.Services.Features.Events.Commands.AddParticipant;

public sealed class AddParticipantHandler(IEventRepository eventRepository, IRepository<User> userRepository)
    : IRequestHandler<AddParticipantCommand>
{
    public async Task Handle(AddParticipantCommand request, CancellationToken cancellationToken)
    {
        var @event = await eventRepository.GetByIdAsync(request.EventId, cancellationToken);

        if (@event == null)
            throw new NotFoundException(EventErrors.NotFoundById(request.EventId));

        var userSpec = new UserByIdSpec(request.UserId);
        var userExists = await userRepository.AnyAsync(userSpec, cancellationToken);

        if (!userExists)
            throw new NotFoundException(UserErrorMessages.UserNotFoundById(request.UserId));

        @event.AddParticipant(request.UserId);

        await eventRepository.UpdateAsync(@event, cancellationToken);
    }
}