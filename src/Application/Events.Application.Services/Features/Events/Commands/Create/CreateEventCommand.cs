using Events.Contracts.Events;
using MediatR;

namespace Events.Application.Services.Features.Events.Commands.Create;

public sealed record CreateEventCommand(CreateEventDto Dto) : IRequest<Guid>;