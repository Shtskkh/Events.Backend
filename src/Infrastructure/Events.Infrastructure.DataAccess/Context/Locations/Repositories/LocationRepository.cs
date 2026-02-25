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
    public async Task<IReadOnlyCollection<Location>> GetAllAsync()
    {
        var locations = await repository.GetAllAsync()
            .AsNoTracking()
            .ToListAsync();

        if (locations.Count == 0)
            throw new NotFoundException(DataAccessErrorMessages.Location.NotFoundAny);

        return locations.AsReadOnly();
    }

    /// <inheritdoc />
    public async Task<Location> GetByIdAsync(int id)
    {
        var location = await repository.GetByIdAsync(id);

        if (location == null)
            throw new NotFoundException(DataAccessErrorMessages.Location.NotFound);

        return location;
    }

    /// <inheritdoc />
    public async Task UpdateAsync(Location location)
    {
        await repository.UpdateAsync(location);
    }

    /// <inheritdoc />
    public async Task<int> AddAsync(Location location)
    {
        await repository.AddAsync(location);
        return location.Id;
    }
}