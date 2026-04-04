using Events.Contracts.Places;
using MediatR;

namespace Events.Application.Services.Features.Places.Commands.Update;

/// <inheritdoc />
public record UpdatePlaceCommand(int LocationId, int PlaceId, UpdatePlaceDto UpdateDto) : IRequest;