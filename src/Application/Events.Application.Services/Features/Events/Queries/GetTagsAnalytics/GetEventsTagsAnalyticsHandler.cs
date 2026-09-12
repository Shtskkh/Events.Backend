using Events.Application.Services.Features.Events.Repositories;
using Events.Application.Services.Shared;
using Events.Contracts.Tags;
using Events.Domain.Aggregates.Events;
using MediatR;

namespace Events.Application.Services.Features.Events.Queries.GetTagsAnalytics;

public class GetEventsTagsAnalyticsHandler(IEventRepository eventRepository)
    : IRequestHandler<GetEventsTagsAnalyticsQuery, IReadOnlyCollection<TagAnalytics>>
{
    public async Task<IReadOnlyCollection<TagAnalytics>> Handle(GetEventsTagsAnalyticsQuery request,
        CancellationToken ct)
    {
        var query = new QueryObject<Event, TagAnalytics>(source =>
        {
            if (request.From.HasValue)
                source = source.Where(e => e.CreatedAt >= request.From.Value.ToUniversalTime());

            if (request.To.HasValue)
                source = source.Where(e => e.CreatedAt <= request.To.Value.ToUniversalTime());

            var temp = source
                .SelectMany(e => e.Tags)
                .GroupBy(t => t.Value)
                .OrderByDescending(g => g.Count());

            return (request.Top.HasValue ? temp.Take(request.Top.Value) : temp)
                .Select(g => new TagAnalytics
                {
                    Tag = g.Key,
                    Count = g.Count()
                });
        });

        return await eventRepository.QueryAsync(query, ct);
    }
}