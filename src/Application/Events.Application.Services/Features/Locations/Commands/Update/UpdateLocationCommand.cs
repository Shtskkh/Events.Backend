using Events.Contracts.Locations;
using MediatR;

namespace Events.Application.Services.Features.Locations.Commands.Update;

/// <inheritdoc />
public sealed record UpdateLocationCommand(int LocationId, UpdateLocationDto UpdateDto) : IRequest;