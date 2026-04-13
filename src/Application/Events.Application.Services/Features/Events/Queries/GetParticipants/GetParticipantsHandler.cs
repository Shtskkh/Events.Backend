using Events.Application.Services.Features.Events.Repositories;
using Events.Application.Services.Features.Users.Specifications;
using Events.Application.Services.Shared;
using Events.Contracts.Events.Participants;
using Events.Domain.Aggregates.UserAggregate;
using MediatR;

namespace Events.Application.Services.Features.Events.Queries.GetParticipants;

public sealed class GetParticipantsHandler(IEventRepository eventRepository, IRepository<User> userRepository)
    : IRequestHandler<GetParticipantsQuery, IReadOnlyCollection<ParticipantDto>>
{
    public async Task<IReadOnlyCollection<ParticipantDto>> Handle(GetParticipantsQuery request,
        CancellationToken cancellationToken)
    {
        const bool includeParticipants = true;
        var @event = await eventRepository.GetByIdAsync(request.Id, cancellationToken, includeParticipants);
        var participantsIds = @event.Participants.Select(p => p.UserId).ToList();

        var spec = new UserSpec().WithIdList(participantsIds).AsNoTracking();
        var participants = await userRepository.ListAsync(spec, cancellationToken);

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

        return dtoList;
    }
}