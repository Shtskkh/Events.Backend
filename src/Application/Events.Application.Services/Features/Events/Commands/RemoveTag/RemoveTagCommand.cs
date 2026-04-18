using MediatR;

namespace Events.Application.Services.Features.Events.Commands.RemoveTag;

public sealed record RemoveTagCommand(Guid EventId, int TagId) : IRequest;