using Events.Application.Services.Features.Events.Repositories;
using Events.Application.Services.Features.Events.Specifications;
using Events.Contracts.Events.EventsTypes;
using MediatR;

namespace Events.Application.Services.Features.Events.Queries.GetTypesAnalytics;

public sealed class GetEventTypesAnalyticsHandler(
    IEventRepository eventRepository)
    : IRequestHandler<GetEventTypesAnalytics, IReadOnlyCollection<EventTypeAnalytics>>
{
    public async Task<IReadOnlyCollection<EventTypeAnalytics>> Handle(GetEventTypesAnalytics request,
        CancellationToken cancellationToken)
    {
        var spec = new EventSpec()
            .CreatedAfter(request.Start.ToUniversalTime())
            .CreatedBefore(request.End.ToUniversalTime())
            .AsNoTracking();

        var events = await eventRepository.GetByFilterAsync(spec, cancellationToken);

        var analytics = events
            .GroupBy(e => e.Type)
            .Select(g => new EventTypeAnalytics
            {
                Type = g.Key.Title,
                Count = g.Count()
            })
            .ToList();

        return analytics;
    }
}