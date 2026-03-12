using MediatR;

namespace Events.Application.Services.Features.Events.Commands.AddParticipant;

/// <inheritdoc />
public record AddParticipantCommand(Guid EventId, Guid UserId) : IRequest;