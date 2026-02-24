using Events.Application.Services.Features.Locations.Repositories;
using Events.Domain.Aggregates.LocationAggregate;
using Events.Infrastructure.DataAccess.Exceptions;
using Events.Infrastructure.DataAccess.Repositories;
using Events.Infrastructure.DataAccess.Shared;
using Microsoft.EntityFrameworkCore;

namespace Events.Infrastructure.DataAccess.Context.Locations.Repositories;

/// <inheritdoc />
public class PlaceTypeRepository(IRepository<PlaceType, int, EventsDbContext> repository) : IPlaceTypeRepository
{
    /// <inheritdoc />
    public async Task<IReadOnlyCollection<PlaceType>> GetAllAsync()
    {
        var types = await repository.GetAllAsync().ToListAsync();

        if (types.Count == 0)
            throw new NotFoundException(DataAccessErrorMessages.Places.Types.NotFoundAny);

        return types.AsReadOnly();
    }
}