using Events.Application.Services.Features.Events.Repositories;
using Events.Application.Services.Features.Locations.Specifications;
using Events.Application.Services.Shared;
using Events.Contracts.Places;
using Events.Domain.Aggregates.LocationAggregate;
using MediatR;

namespace Events.Application.Services.Features.Places.Queries.GetAvailable;

/// <inheritdoc />
public sealed class GetAvailablePlacesQueryHandler(
    IRepository<Location> locationRepository,
    IEventRepository eventRepository)
    : IRequestHandler<GetAvailablePlacesQuery, IReadOnlyCollection<PlaceAvailabilityDto>>
{
    /// <inheritdoc />
    public async Task<IReadOnlyCollection<PlaceAvailabilityDto>> Handle(GetAvailablePlacesQuery request,
        CancellationToken cancellationToken)
    {
        var spec = new LocationSpec().WithId(request.LocationId).IncludePlaces().AsNoTracking();
        var locations = await locationRepository.FirstOrDefaultAsync(spec, cancellationToken);

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