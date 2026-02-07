using Ardalis.Specification;
using Ardalis.Specification.EntityFrameworkCore;
using Events.Application.Services.Features.Events.Repositories;
using Events.Domain.Aggregates.EventAggregate;
using Events.Infrastructure.DataAccess.Exceptions;
using Events.Infrastructure.DataAccess.Repositories;
using Events.Infrastructure.DataAccess.Shared;
using Microsoft.EntityFrameworkCore;

namespace Events.Infrastructure.DataAccess.Context.Events.Repositories;

/// <inheritdoc />
public class EventRepository(IRepository<Event, Guid, EventsDbContext> repository) : IEventRepository
{
    /// <inheritdoc />
    public async Task<Event> GetByIdAsync(Guid id)
    {
        var isExists = await repository.IsExistsAsync(id);

        if (!isExists) throw new NotFoundException(DataAccessErrorMessages.Event.NotFound);

        return (await repository.GetByIdAsync(id))!;
    }

    /// <inheritdoc />
    public async Task<IReadOnlyCollection<Event>> GetByFilterAsync(Specification<Event> spec)
    {
        var events = await repository
            .GetAllAsync()
            .WithSpecification(spec)
            .ToListAsync();

        return events.AsReadOnly();
    }

    /// <inheritdoc />
    public async Task AddAsync(Event @event)
    {
        await repository.AddAsync(@event);
    }
}