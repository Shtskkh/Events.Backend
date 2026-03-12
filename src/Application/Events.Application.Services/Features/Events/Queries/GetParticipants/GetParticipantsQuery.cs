using Events.Contracts.Features.Events.Participants;
using MediatR;

namespace Events.Application.Services.Features.Events.Queries.GetParticipants;

/// <inheritdoc />
public record GetParticipantsQuery(Guid Id) : IRequest<IReadOnlyCollection<ParticipantDto>>;