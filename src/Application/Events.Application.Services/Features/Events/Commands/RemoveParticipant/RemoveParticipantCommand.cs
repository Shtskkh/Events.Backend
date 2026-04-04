using MediatR;

namespace Events.Application.Services.Features.Events.Commands.RemoveParticipant;

/// <inheritdoc />
public sealed record RemoveParticipantCommand(Guid EventId, Guid ParticipantId) : IRequest;