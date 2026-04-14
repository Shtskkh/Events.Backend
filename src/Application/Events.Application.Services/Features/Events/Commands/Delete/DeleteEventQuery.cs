using MediatR;

namespace Events.Application.Services.Features.Events.Commands.Delete;

public sealed record DeleteEventQuery(Guid EventId) : IRequest;