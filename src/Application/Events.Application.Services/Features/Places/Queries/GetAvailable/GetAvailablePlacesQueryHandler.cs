using Events.Application.Services.Features.Events.Repositories;
using Events.Application.Services.Features.Locations.Repositories;
using Events.Application.Services.Features.Locations.Specifications;
using Events.Contracts.Places;
using MediatR;

namespace Events.Application.Services.Features.Places.Queries.GetAvailable;

/// <inheritdoc />
public sealed class GetAvailablePlacesQueryHandler(
    ILocationRepository locationRepository,
    IEventRepository eventRepository)
    : IRequestHandler<GetAvailablePlacesQuery, IReadOnlyCollection<PlaceAvailabilityDto>>
{
    /// <inheritdoc />
    public async Task<IReadOnlyCollection<PlaceAvailabilityDto>> Handle(GetAvailablePlacesQuery request,
        CancellationToken cancellationToken)
    {
        var spec = new LocationByIdSpec(request.LocationId).WithPlaces().AsNoTracking();
        var locations = await locationRepository.GetAsync(spec, cancellationToken);

        var conflictChecks = locations.Places.Select(async place =>
        {
            var hasConflict = await eventRepository.HasBookingConflictAsync(
                place.Id,
                request.Start,
                request.End,
                cancellationToken
            );

            return new PlaceAvailabilityDto
            {
                Id = place.Id,
                Number = place.Number.Value,
                Capacity = place.Capacity.Value,
                Type = place.Type.Title,
                IsAvailable = !hasConflict,
                Title = place.Type.Title
            };
        });

        var places = await Task.WhenAll(conflictChecks);

        return places;
    }
}