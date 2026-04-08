using Ardalis.Specification;
using Ardalis.Specification.EntityFrameworkCore;
using Events.Application.Services.Features.Places.Repositories;
using Events.Domain.Aggregates.LocationAggregate;
using Events.Domain.Aggregates.LocationAggregate.Errors;
using Events.Domain.Exceptions;
using Events.Infrastructure.DataAccess.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Events.Infrastructure.DataAccess.Context.Locations.Repositories;

/// <inheritdoc />
public class PlaceRepository(IRepository<Place, int, EventsDbContext> repository) : IPlaceRepository
{
    /// <inheritdoc />
    public async Task<IReadOnlyCollection<Place>> GetByFilterAsync(Specification<Place> spec,
        CancellationToken cancellationToken)
    {
        var places = await repository.GetAllAsync()
            .WithSpecification(spec)
            .ToListAsync(cancellationToken);

        if (places == null)
            throw new NotFoundException(PlaceErrorMessages.NotFoundAny);

        return places;
    }

    /// <inheritdoc />
    public async Task<Place> GetAsync(Specification<Place> spec, CancellationToken cancellationToken)
    {
        var place = await repository.GetAllAsync()
            .WithSpecification(spec)
            .FirstOrDefaultAsync(cancellationToken);

        if (place == null)
            throw new NotFoundException(PlaceErrorMessages.NotFound);

        return place;
    }

    /// <inheritdoc />
    public async Task<Place> GetById(int id, CancellationToken cancellationToken)
    {
        var place = await repository.GetByIdAsync(id, cancellationToken);

        if (place == null)
            throw new NotFoundException(PlaceErrorMessages.NotFound);

        return place;
    }

    /// <inheritdoc />
    public async Task UpdateAsync(Place place, CancellationToken cancellationToken)
    {
        await repository.UpdateAsync(place, cancellationToken);
    }
}