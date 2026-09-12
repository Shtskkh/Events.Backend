using Events.Contracts.Locations;
using MediatR;

namespace Events.Application.Services.Features.Locations.Commands.Create;

public sealed record CreateLocationCommand(CreateLocationDto Dto) : IRequest<int>;