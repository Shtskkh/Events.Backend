using MediatR;

namespace Events.Application.Services.Features.Locations.Commands.DeletePlace;

/// <inheritdoc />
public record DeletePlaceCommand(int LocationId, int PlaceId) : IRequest;