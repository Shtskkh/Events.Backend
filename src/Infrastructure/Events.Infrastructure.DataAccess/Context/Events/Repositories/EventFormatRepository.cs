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
        var isExists = await repository.IsExistsAsync(id);

        if (!isExists) throw new NotFoundException(DataAccessErrorMessages.Event.Format.NotFound);

        return (await repository.GetByIdAsync(id, cancellationToken))!;
    }

    /// <inheritdoc />
    public async Task<IReadOnlyCollection<EventFormat>> GetAllAsync()
    {
        var types = await repository.GetAllAsync().AsNoTracking().ToListAsync();

        return types.AsReadOnly();
    }
}