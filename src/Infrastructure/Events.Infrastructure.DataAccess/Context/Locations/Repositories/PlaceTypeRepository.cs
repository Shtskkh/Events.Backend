using Events.Application.Services.Features.Places.Repositories;
using Events.Domain.Aggregates.LocationAggregate;
using Events.Domain.Exceptions;
using Events.Infrastructure.DataAccess.Repositories;
using Events.Infrastructure.DataAccess.Shared;
using Microsoft.EntityFrameworkCore;

namespace Events.Infrastructure.DataAccess.Context.Locations.Repositories;

/// <inheritdoc />
public class PlaceTypeRepository(IRepository<PlaceType, int, EventsDbContext> repository) : IPlaceTypeRepository
{
    /// <inheritdoc />
    public async Task<IReadOnlyCollection<PlaceType>> GetAllAsync(CancellationToken cancellationToken)
    {
        var types = await repository.GetAllAsync()
            .AsNoTracking()
            .ToListAsync(cancellationToken);

        if (types.Count == 0)
            throw new NotFoundException(DataAccessErrorMessages.Places.Types.NotFoundAny);

        return types.AsReadOnly();
    }

    /// <inheritdoc />
    public async Task<PlaceType> GetByIdAsync(int id, CancellationToken cancellationToken)
    {
        var type = await repository.GetByIdAsync(id, cancellationToken);

        if (type == null)
            throw new NotFoundException(DataAccessErrorMessages.Places.Types.NotFound);

        return type;
    }
}