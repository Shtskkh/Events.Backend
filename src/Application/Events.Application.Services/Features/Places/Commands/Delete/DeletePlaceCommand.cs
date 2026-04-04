using MediatR;

namespace Events.Application.Services.Features.Places.Commands.Delete;

/// <inheritdoc />
public record DeletePlaceCommand(int LocationId, int PlaceId) : IRequest;