using Events.Contracts.Locations;
using MediatR;

namespace Events.Application.Services.Features.Locations.Commands.Update;

public sealed record UpdateLocationCommand(int LocationId, UpdateLocationDto UpdateDto) : IRequest;