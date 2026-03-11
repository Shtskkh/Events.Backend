using Events.Application.Services.Features.Locations.Repositories;
using Events.Domain.Aggregates.LocationAggregate;
using Events.Infrastructure.DataAccess.Exceptions;
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
        if (includePlaces)
        {
            var location = await repository.GetAllAsync()
                .Include(l => l.Places)
                .FirstOrDefaultAsync(l => l.Id == id, cancellationToken);

            if (location == null)
                throw new NotFoundException(DataAccessErrorMessages.Location.NotFound);

            return location;
        }
        else
        {
            var location = await repository.GetByIdAsync(id, cancellationToken);

            if (location == null)
                throw new NotFoundException(DataAccessErrorMessages.Location.NotFound);

            return location;
        }
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
}