using Events.Application.Services.Features.Events.Repositories;
using Events.Application.Services.Shared;
using Events.Contracts.Events.EventsFormats;
using Events.Domain.Aggregates.Events;
using MediatR;

namespace Events.Application.Services.Features.Events.Queries.GetEventFormatsAnalytics;

public class GetEventFormatsAnalyticsHandler(
    IEventRepository eventRepository)
    : IRequestHandler<GetEventFormatsAnalyticsQuery, IReadOnlyCollection<EventFormatAnalyticsDto>>
{
    public async Task<IReadOnlyCollection<EventFormatAnalyticsDto>> Handle(GetEventFormatsAnalyticsQuery request,
        CancellationToken cancellationToken)
    {
        var query = new QueryObject<Event, EventFormatAnalyticsDto>(source =>
        {
            if (request.Start.HasValue)
                source = source.Where(e => e.CreatedAt >= request.Start.Value.ToUniversalTime());

            if (request.End.HasValue)
                source = source.Where(e => e.CreatedAt <= request.End.Value.ToUniversalTime());

            return source
                .GroupBy(e => e.Format.Title)
                .Select(g => new EventFormatAnalyticsDto
                {
                    Format = g.Key,
                    Count = g.Count()
                });
        });

        return await eventRepository.QueryAsync(query, cancellationToken);
    }
}