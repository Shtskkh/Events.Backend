using Ardalis.Specification.EntityFrameworkCore;
using Events.Application.Services.Features.Locations.Repositories;
using Events.Application.Services.Features.Locations.Specifications;
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
    public async Task<Location> GetAsync(
        BaseLocationSpec spec,
        CancellationToken cancellationToken)
    {
        var location = await repository
            .GetAllAsync()
            .WithSpecification(spec)
            .FirstOrDefaultAsync(cancellationToken);

        if (location is null)
            throw new NotFoundException(DataAccessErrorMessages.Location.NotFound);

        return location;
    }

    /// <inheritdoc />
    public async Task AddAsync(Location location, CancellationToken cancellationToken)
    {
        await repository.AddAsync(location, cancellationToken);
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