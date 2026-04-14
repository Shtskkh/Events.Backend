using Events.Application.Services.Features.Events.Repositories;
using Events.Application.Services.Shared;
using Events.Contracts.Events.EventsTypes;
using Events.Domain.Aggregates.Events;
using MediatR;

namespace Events.Application.Services.Features.Events.Queries.GetTypesAnalytics;

public sealed class GetEventTypesAnalyticsHandler(
    IEventRepository eventRepository)
    : IRequestHandler<GetEventTypesAnalytics, IReadOnlyCollection<EventTypeAnalyticsDto>>
{
    public async Task<IReadOnlyCollection<EventTypeAnalyticsDto>> Handle(GetEventTypesAnalytics request,
        CancellationToken cancellationToken)
    {
        var query = new QueryObject<Event, EventTypeAnalyticsDto>(source =>
        {
            if (request.Start.HasValue)
                source = source.Where(e => e.CreatedAt >= request.Start.Value.ToUniversalTime());

            if (request.End.HasValue)
                source = source.Where(e => e.CreatedAt <= request.End.Value.ToUniversalTime());

            return source
                .GroupBy(e => e.Type.Title)
                .Select(g => new EventTypeAnalyticsDto
                {
                    Type = g.Key,
                    Count = g.Count()
                });
        });

        return await eventRepository.QueryAsync(query, cancellationToken);
    }
}