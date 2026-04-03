using Events.Application.Services.Features.Locations.Repositories;
using Events.Domain.Aggregates.LocationAggregate;
using Events.Domain.Aggregates.LocationAggregate.Errors;
using Events.Domain.Exceptions;
using Events.Domain.Shared;
using Events.Infrastructure.DataAccess.Repositories;

namespace Events.Infrastructure.DataAccess.Context.Locations.Repositories;

/// <inheritdoc />
public class PlaceRepository(IRepository<Place, int, EventsDbContext> repository) : IPlaceRepository
{
    /// <inheritdoc />
    public async Task<Place> GetById(int id, CancellationToken cancellationToken)
    {
        var place = await repository.GetByIdAsync(id, cancellationToken);

        if (place == null)
            throw new NotFoundException(PlaceErrorMessages.NotFound);

        return place;
    }
}