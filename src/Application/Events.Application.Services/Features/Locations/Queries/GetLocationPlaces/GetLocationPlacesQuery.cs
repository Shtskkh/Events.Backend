using Events.Contracts.Features.Locations.Places;
using MediatR;

namespace Events.Application.Services.Features.Locations.Queries.GetLocationPlaces;

/// <inheritdoc />
public record GetLocationPlacesQuery(int Id) : IRequest<IReadOnlyCollection<ShortPlaceDto>>;