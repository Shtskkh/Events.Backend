using Events.Contracts.Features.Locations.Places;
using MediatR;

namespace Events.Application.Services.Features.Locations.Queries.GetPlaceById;

/// <inheritdoc />
public record GetPlaceByIdQuery(int LocationId, int PlaceId) : IRequest<PlaceDto>;