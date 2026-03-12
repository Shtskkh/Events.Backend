using Events.Application.Services.Features.Locations.Repositories;
using Events.Domain.Aggregates.LocationAggregate;
using Events.Domain.Exceptions;
using Events.Infrastructure.DataAccess.Repositories;
using Events.Infrastructure.DataAccess.Shared;
using Microsoft.EntityFrameworkCore;

namespace Events.Infrastructure.DataAccess.Context.Locations.Repositories;

/// <inheritdoc />
public class LocationRepository(IRepository<Location, int, EventsDbContext> repository) : ILocationRepository
{
    /// <inheritdoc />
    public async Task<IReadOnlyCollection<Location>> GetAllAsync(CancellationToken cancellationToken)
    {
        var locations = await repository.GetAllAsync()
            .AsNoTracking()
            .ToListAsync(cancellationToken);

        if (locations.Count == 0)
            throw new NotFoundException(DataAccessErrorMessages.Location.NotFoundAny);

        return locations.AsReadOnly();
    }

    /// <inheritdoc />
    public async Task<Location> GetByIdAsync(int id, bool includePlaces, CancellationToken cancellationToken)
    {
        var query = repository.GetAllAsync();
        if (includePlaces)
            query = query.Include(l => l.Places);

        var location = await query.FirstOrDefaultAsync(l => l.Id == id, cancellationToken);
        if (location == null)
            throw new NotFoundException(DataAccessErrorMessages.Location.NotFound);

        return location;
    }

    /// <inheritdoc />
    public async Task<IReadOnlyCollection<Place>> GetAllPlacesAsync(int id, CancellationToken cancellationToken)
    {
        var location = await repository.GetAllAsync()
            .Include(l => l.Places)
            .FirstOrDefaultAsync(l => l.Id == id, cancellationToken);

        if (location == null)
            throw new NotFoundException(DataAccessErrorMessages.Location.NotFound);

        if (location.Places.Count == 0)
            throw new NotFoundException(DataAccessErrorMessages.Places.NotFoundAny);

        return location.Places;
    }

    /// <inheritdoc />
    public async Task<Place> GetPlaceByIdAsync(int locationId, int placeId, CancellationToken cancellationToken)
    {
        const bool includePlaces = true;
        var location = await GetByIdAsync(locationId, includePlaces, cancellationToken);
        var place = location.Places.FirstOrDefault(p => p.Id == placeId);

        if (place == null)
            throw new DomainException(DataAccessErrorMessages.Places.NotFound);

        return place;
    }

    /// <inheritdoc />
    public async Task<int> AddAsync(Location location, CancellationToken cancellationToken)
    {
        await repository.AddAsync(location, cancellationToken);
        return location.Id;
    }

    /// <inheritdoc />
    public async Task UpdateAsync(Location location, CancellationToken cancellationToken)
    {
        await repository.UpdateAsync(location, cancellationToken);
    }

    /// <inheritdoc />
    public async Task DeleteAsync(Location location, CancellationToken cancellationToken)
    {
        await repository.DeleteAsync(location, cancellationToken);
    }
}