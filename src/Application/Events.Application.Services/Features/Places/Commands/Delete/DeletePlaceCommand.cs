using MediatR;

namespace Events.Application.Services.Features.Places.Commands.Delete;

public sealed record DeletePlaceCommand(int LocationId, int PlaceId) : IRequest;