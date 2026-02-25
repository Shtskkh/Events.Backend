using Events.Application.Services.Features.Locations.Repositories;
using Events.Domain.Aggregates.LocationAggregate;
using Events.Infrastructure.DataAccess.Repositories;

namespace Events.Infrastructure.DataAccess.Context.Locations.Repositories;

/// <inheritdoc />
public class PlaceRepository(IRepository<Place, int, EventsDbContext> repository) : IPlaceRepository
{
    /// <inheritdoc />
    public async Task<int> AddPlaceAsync(Place place)
    {
        await repository.AddAsync(place);
        return place.Id;
    }
}