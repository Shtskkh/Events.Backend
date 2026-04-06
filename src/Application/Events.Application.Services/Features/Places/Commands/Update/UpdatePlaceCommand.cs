using Events.Contracts.Places;
using MediatR;

namespace Events.Application.Services.Features.Places.Commands.Update;

/// <inheritdoc />
public sealed record UpdatePlaceCommand(int PlaceId, UpdatePlaceDto UpdateDto) : IRequest;