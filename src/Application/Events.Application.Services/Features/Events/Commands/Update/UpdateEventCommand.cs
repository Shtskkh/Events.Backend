using Events.Contracts.Events;
using MediatR;

namespace Events.Application.Services.Features.Events.Commands.Update;

/// <inheritdoc />
public record UpdateEventCommand(Guid Id, UpdateEventDto Dto) : IRequest;