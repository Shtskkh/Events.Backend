using Events.Application.Services.Features.Events.Repositories;
using Events.Domain.Aggregates.EventAggregate;
using Events.Infrastructure.DataAccess.Exceptions;
using Events.Infrastructure.DataAccess.Repositories;
using Events.Infrastructure.DataAccess.Shared;
using Microsoft.EntityFrameworkCore;

namespace Events.Infrastructure.DataAccess.Context.Events.Repositories;

/// <inheritdoc />
public class EventFormatRepository(IRepository<EventFormat, int, EventsDbContext> repository) : IEventFormatRepository
{
    /// <inheritdoc />
    public async Task<EventFormat> GetByIdAsync(int id, CancellationToken cancellationToken)
    {
        var format = await repository.GetByIdAsync(id, cancellationToken);

        if (format == null)
            throw new NotFoundException(DataAccessErrorMessages.Event.Format.NotFound);

        return format;
    }

    /// <inheritdoc />
    public async Task<IReadOnlyCollection<EventFormat>> GetAllAsync(CancellationToken cancellationToken)
    {
        var types = await repository.GetAllAsync().AsNoTracking().ToListAsync(cancellationToken);

        return types.AsReadOnly();
    }
}