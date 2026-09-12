using Ardalis.Specification;
using Events.Application.Services.Features.Events.Repositories;
using Events.Domain.Aggregates.Events;
using Events.Infrastructure.DataAccess.Shared;
using Microsoft.EntityFrameworkCore;

namespace Events.Infrastructure.DataAccess.Context.Events.Repositories;

public class EventRepository(EventsDbContext dbContext) : Repository<Event>(dbContext), IEventRepository
{
    /// <inheritdoc />
    public async Task<List<Event>> ListAsync(ISpecification<Event> spec,
        CancellationToken cancellationToken = default,
        string? textQuery = null)
    {
        var query = ApplySpecification(spec);

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

        return await query.ToListAsync(cancellationToken);
    }

    private static string PrepareQuery(string text)
    {
        var tokens = text
            .Split([' ', ',', '.', '\t', '\n'], StringSplitOptions.RemoveEmptyEntries)
            .Distinct()
            .Select(w => w.Trim() + ":*");

        return string.Join(" & ", tokens);
    }
}