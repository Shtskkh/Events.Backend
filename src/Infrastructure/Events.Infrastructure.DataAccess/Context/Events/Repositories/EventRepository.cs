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
    public async Task AddAsync(Event @event)
    {
        await repository.AddAsync(@event);
    }

    /// <inheritdoc />
    public async Task DeleteAsync(Event @event)
    {
        await repository.DeleteAsync(@event);
    }

    /// <inheritdoc />
    public async Task<IReadOnlyCollection<Event>> GetByFilterAsync(
        Specification<Event> spec,
        string? textQuery = null,
        CancellationToken cancellationToken = default
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