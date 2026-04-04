using MediatR;

namespace Events.Application.Services.Features.Places.Commands.Delete;

/// <inheritdoc />
public sealed record DeletePlaceCommand(int LocationId, int PlaceId) : IRequest;