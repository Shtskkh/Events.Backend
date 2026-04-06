using Events.Contracts.Places;
using MediatR;

namespace Events.Application.Services.Features.Places.Queries.GetById;

/// <inheritdoc />
public sealed record GetPlaceByIdQuery(int PlaceId) : IRequest<PlaceDto>;