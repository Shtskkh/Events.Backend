using Events.Contracts.Locations;
using MediatR;

namespace Events.Application.Services.Features.Locations.Commands.UpdateLocation;

/// <inheritdoc />
public record UpdateLocationCommand(int LocationId, UpdateLocationDto UpdateDto) : IRequest;