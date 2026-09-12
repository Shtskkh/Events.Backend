using Events.Application.Services.Features.Events.Repositories;
using Events.Application.Services.Shared;
using Events.Contracts.Locations;
using Events.Domain.Aggregates.Events;
using Events.Domain.Aggregates.Locations;
using MediatR;

namespace Events.Application.Services.Features.Events.Queries.GetLocationAnalytics;

public class GetEventsLocationsAnalyticsHandler(
    IEventRepository eventRepository,
    IRepository<Location> locationRepository)
    : IRequestHandler<GetEventsLocationsAnalyticsQuery, IReadOnlyCollection<LocationAnalyticsDto>>
{
    public async Task<IReadOnlyCollection<LocationAnalyticsDto>> Handle(GetEventsLocationsAnalyticsQuery request,
        CancellationToken cancellationToken)
    {
        var query = new QueryObject<Event, LocationCount>(source =>
        {
            if (request.From.HasValue)
                source = source.Where(e => e.CreatedAt >= request.From);

            if (request.To.HasValue)
                source = source.Where(e => e.CreatedAt <= request.To);

            return source
                .Where(e => e.Booking != null)
                .GroupBy(e => e.Booking.LocationId)
                .Select(g => new LocationCount(g.Key, g.Count()))
                .OrderByDescending(lc => lc.Count);
        });

        var analytics = await eventRepository.QueryAsync(query, cancellationToken);
        var locations = await locationRepository.ListAsync(cancellationToken);

        return analytics.Join(locations,
            a => a.LocationId,
            l => l.Id,
            (a, l) => new LocationAnalyticsDto
            {
                Title = l.Title.Value,
                Count = a.Count
            }).ToList();
    }

    private record LocationCount(int LocationId, int Count);
}