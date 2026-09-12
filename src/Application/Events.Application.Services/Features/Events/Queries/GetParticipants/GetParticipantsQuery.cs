using Events.Contracts.Events.Participants;
using MediatR;

namespace Events.Application.Services.Features.Events.Queries.GetParticipants;

public sealed record GetParticipantsQuery(Guid EventId) : IRequest<IReadOnlyCollection<ParticipantDto>>;