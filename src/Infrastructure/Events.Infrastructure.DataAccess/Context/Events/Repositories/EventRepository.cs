using Ardalis.Specification;
using Ardalis.Specification.EntityFrameworkCore;
using Events.Application.Services.Features.Events.Repositories;
using Events.Domain.Aggregates.EventAggregate;
using Events.Domain.Exceptions;
using Events.Infrastructure.DataAccess.Repositories;
using Events.Infrastructure.DataAccess.Shared;
using Microsoft.EntityFrameworkCore;

namespace Events.Infrastructure.DataAccess.Context.Events.Repositories;

/// <inheritdoc />
public class EventRepository(IRepository<Event, Guid, EventsDbContext> repository) : IEventRepository
{
    /// <inheritdoc />
    public async Task<Event> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        var @event = await repository.GetByIdAsync(id, cancellationToken);

        if (@event == null)
            throw new NotFoundException(DataAccessErrorMessages.Event.NotFound);

        return @event;
    }

    /// <inheritdoc />
    public async Task AddAsync(Event @event, CancellationToken cancellationToken)
    {
        await repository.AddAsync(@event, cancellationToken);
    }

    /// <inheritdoc />
    public async Task UpdateAsync(Event @event, CancellationToken cancellationToken)
    {
        await repository.UpdateAsync(@event, cancellationToken);
    }

    /// <inheritdoc />
    public async Task DeleteAsync(Event @event, CancellationToken cancellationToken)
    {
        await repository.DeleteAsync(@event, cancellationToken);
    }

    /// <inheritdoc />
    public async Task<IReadOnlyCollection<Event>> GetByFilterAsync(
        Specification<Event> spec,
        CancellationToken cancellationToken,
        string? textQuery = null
    )
    {
        var query = repository
            .GetAllAsync()
            .WithSpecification(spec);

        if (textQuery != null)
        {
            var preparedText = PrepareQuery(textQuery);
            query = query.Where(e =>
                EF.Functions.ToTsVector(
                        "russian",
                        e.Title.Value + ' ' +
                        e.Announcement.Value + ' ' +
                        e.Description.Value)
                    .Matches(EF.Functions.ToTsQuery("russian", preparedText)));
        }

        var events = await query.ToListAsync(cancellationToken);

        if (events.Count == 0)
            throw new NotFoundException(DataAccessErrorMessages.Event.NotFoundAny);

        return events.AsReadOnly();
    }

    private static string PrepareQuery(string text)
    {
        var prepared = string.Join(" & ", text
            .Split([' ', ',', '.', '\t', '\n'], StringSplitOptions.RemoveEmptyEntries)
            .Distinct()
            .Select(w => w.Trim()));

        return prepared;
    }
}