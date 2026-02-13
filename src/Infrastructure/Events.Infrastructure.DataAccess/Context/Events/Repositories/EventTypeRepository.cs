using Events.Application.Services.Features.Events.Repositories;
using Events.Application.Services.Features.EventsTypes.Repositories;
using Events.Domain.Aggregates.EventAggregate;
using Events.Infrastructure.DataAccess.Exceptions;
using Events.Infrastructure.DataAccess.Repositories;
using Events.Infrastructure.DataAccess.Shared;
using Microsoft.EntityFrameworkCore;

namespace Events.Infrastructure.DataAccess.Context.Events.Repositories;

/// <inheritdoc />
public class EventTypeRepository(IRepository<EventType, int, EventsDbContext> repository) : IEventTypeRepository
{
    /// <inheritdoc />
    public async Task<EventType> GetById(int id)
    {
        var isExists = await repository.IsExistsAsync(id);

        if (!isExists) throw new NotFoundException(DataAccessErrorMessages.Event.Type.NotFound);

        return (await repository.GetByIdAsync(id))!;
    }

    /// <inheritdoc />
    public async Task<IReadOnlyCollection<EventType>> GetAllAsync()
    {
        var eventsTypes = await repository.GetAllAsync().AsNoTracking().ToListAsync();

        return eventsTypes.AsReadOnly();
    }
}