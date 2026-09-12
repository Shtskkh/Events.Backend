using Events.Contracts.Places;
using MediatR;

namespace Events.Application.Services.Features.Locations.Queries.GetPlaces;

/// <inheritdoc />
public sealed record GetLocationPlacesQuery(int LocationId) : IRequest<IReadOnlyCollection<ShortPlaceDto>>;