using Events.Application.Services.Features.Events.Repositories;
using Events.Application.Services.Features.Events.Specifications;
using Events.Application.Services.Features.Users.Specifications;
using Events.Application.Services.Shared;
using Events.Contracts.Events.Participants;
using Events.Domain.Aggregates.Events.Errors;
using Events.Domain.Aggregates.Users;
using Events.Domain.Exceptions;
using MediatR;

namespace Events.Application.Services.Features.Events.Queries.GetParticipants;

public sealed class GetParticipantsHandler(IEventRepository eventRepository, IRepository<User> userRepository)
    : IRequestHandler<GetParticipantsQuery, IReadOnlyCollection<ParticipantDto>>
{
    public async Task<IReadOnlyCollection<ParticipantDto>> Handle(GetParticipantsQuery request,
        CancellationToken cancellationToken)
    {
        var eventByIdSpec = new EventByIdSpec(request.EventId).IncludeParticipants().AsNoTracking();

        var @event = await eventRepository.FirstOrDefaultAsync(eventByIdSpec, cancellationToken);

        if (@event == null)
            throw new NotFoundException(EventErrors.NotFoundById(request.EventId));

        if (@event.Participants.Count == 0)
            throw new NotFoundException(EventParticipantErrors.NotFoundAny);

        var participantsIds = @event.Participants.Select(p => p.UserId).ToList();

        var usersByIdsSpec = new UsersByIdsSpec(participantsIds).AsNoTracking();
        var participants = await userRepository.ListAsync(usersByIdsSpec, cancellationToken);

        var participantsById = participants.ToDictionary(p => p.Id);

        return @event.Participants.Select(p =>
        {
            var user = participantsById[p.UserId];
            return new ParticipantDto
            {
                Id = p.UserId,
                LastName = user.PersonName.LastName,
                FirstName = user.PersonName.FirstName,
                Patronymic = user.PersonName.Patronymic,
                RegistrationTime = p.RegistrationTime
            };
        }).ToList();
    }
}