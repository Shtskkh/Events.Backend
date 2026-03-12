using Events.Contracts.Features.Locations.Places;
using MediatR;

namespace Events.Application.Services.Features.Locations.Commands.UpdatePlace;

/// <inheritdoc />
public record UpdatePlaceCommand(int LocationId, int PlaceId, UpdatePlaceDto UpdateDto) : IRequest;