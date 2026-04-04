using Events.Contracts.Places;
using MediatR;

namespace Events.Application.Services.Features.Places.Queries.GetById;

/// <inheritdoc />
public record GetPlaceByIdQuery(int LocationId, int PlaceId) : IRequest<PlaceDto>;