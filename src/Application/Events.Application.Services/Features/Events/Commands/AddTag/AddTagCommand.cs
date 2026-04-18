using MediatR;

namespace Events.Application.Services.Features.Events.Commands.AddTag;

public sealed record AddTagCommand(Guid EventId, int TagId) : IRequest;