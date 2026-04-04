using MediatR;

namespace Events.Application.Services.Features.Events.Commands.AddParticipant;

/// <inheritdoc />
public sealed record AddParticipantCommand(Guid EventId, Guid UserId) : IRequest;