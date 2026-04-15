using Events.Application.Services.Features.Events.Repositories;
using Events.Application.Services.Features.Events.Specifications;
using Events.Application.Services.Features.Locations.Specifications;
using Events.Application.Services.Shared;
using Events.Contracts.Places;
using Events.Domain.Aggregates.Locations;
using Events.Domain.Aggregates.Locations.Errors;
using Events.Domain.Exceptions;
using MediatR;

namespace Events.Application.Services.Features.Locations.Queries.GetAvailablePlaces;

public sealed class GetAvailablePlacesQueryHandler(
    IRepository<Location> locationRepository,
    IEventRepository eventRepository)
    : IRequestHandler<GetAvailablePlacesQuery, IReadOnlyCollection<PlaceAvailabilityDto>>
{
    public async Task<IReadOnlyCollection<PlaceAvailabilityDto>> Handle(GetAvailablePlacesQuery request,
        CancellationToken cancellationToken)
    {
        var locationSpec = new LocationByIdSpec(request.LocationId).IncludePlaces().AsNoTracking();
        var location = await locationRepository.FirstOrDefaultAsync(locationSpec, cancellationToken);

        if (location == null)
            throw new NotFoundException(LocationErrors.NotFoundById(request.LocationId));

        var conflictChecksTasks = location.Places.Select(async place =>
        {
            var hasConflict = await eventRepository.AnyAsync(
                new HasBookingConflictSpec(
                    place.Id,
                    request.Start.ToUniversalTime(),
                    request.End.ToUniversalTime()),
                cancellationToken);

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

        var availablePlaces = await Task.WhenAll(conflictChecksTasks);

        return availablePlaces;
    }
}