using Events.Application.Services.Features.Events.Repositories;
using Events.Application.Services.Features.Events.Specifications;
using Events.Application.Services.Features.Users.Repositories;
using Events.Contracts.Events.Participants;
using MediatR;

namespace Events.Application.Services.Features.Events.Queries.GetParticipants;

/// <inheritdoc />
public class GetParticipantsHandler(IEventRepository eventRepository, IUserRepository userRepository)
    : IRequestHandler<GetParticipantsQuery, IReadOnlyCollection<ParticipantDto>>
{
    /// <inheritdoc />
    public async Task<IReadOnlyCollection<ParticipantDto>> Handle(GetParticipantsQuery request,
        CancellationToken cancellationToken)
    {
        const bool includeParticipants = true;
        var @event = await eventRepository.GetByIdAsync(request.Id, cancellationToken, includeParticipants);
        var participantsIds = @event.Participants.Select(p => p.UserId).ToList();

        var participants =
            await userRepository.GetByFilterAsync(new EventParticipantsSpecification(participantsIds),
                cancellationToken);

        var participantsById = participants.ToDictionary(p => p.Id);

        var dtoList = @event.Participants.Select(p =>
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

        return dtoList.AsReadOnly();
    }
}