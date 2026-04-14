using Events.Contracts.Places;
using MediatR;

namespace Events.Application.Services.Features.Locations.Queries.GetAvailablePlaces;

public sealed record GetAvailablePlacesQuery(
    int LocationId,
    DateTimeOffset Start,
    DateTimeOffset End
) : IRequest<IReadOnlyCollection<PlaceAvailabilityDto>>;