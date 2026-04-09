using Events.Application.Services.Features.Events.Repositories;
using Events.Application.Services.Features.Events.Specifications;
using Events.Contracts.Events.EventsFormats;
using MediatR;

namespace Events.Application.Services.Features.Events.Queries.GetEventFormatsAnalytics;

public class GetEventFormatsAnalyticsHandler(
    IEventRepository eventRepository)
    : IRequestHandler<GetEventFormatsAnalyticsQuery, IReadOnlyCollection<EventFormatAnalytics>>
{
    public async Task<IReadOnlyCollection<EventFormatAnalytics>> Handle(GetEventFormatsAnalyticsQuery request,
        CancellationToken cancellationToken)
    {
        var spec = new EventSpec()
            .CreatedAfter(request.Start.ToUniversalTime())
            .CreatedBefore(request.End.ToUniversalTime())
            .AsNoTracking();

        var events = await eventRepository.GetByFilterAsync(spec, cancellationToken);

        var analytics = events
            .GroupBy(e => e.Format)
            .Select(g => new EventFormatAnalytics
            {
                Format = g.Key.Title,
                Count = g.Count()
            })
            .ToList();

        return analytics;
    }
}