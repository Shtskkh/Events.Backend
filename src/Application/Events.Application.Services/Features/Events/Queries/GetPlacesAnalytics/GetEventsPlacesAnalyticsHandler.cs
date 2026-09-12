using Events.Application.Services.Features.Events.Repositories;
using Events.Application.Services.Features.Places.Specifications;
using Events.Application.Services.Shared;
using Events.Contracts.Places;
using Events.Domain.Aggregates.Events;
using Events.Domain.Aggregates.Locations;
using MediatR;

namespace Events.Application.Services.Features.Events.Queries.GetPlacesAnalytics;

public class GetEventsPlacesAnalyticsHandler(
    IEventRepository eventRepository,
    IRepository<Place> placeRepository,
    IRepository<Location> locationRepository)
    : IRequestHandler<GetEventsPlacesAnalyticsQuery, IReadOnlyCollection<PlaceAnalyticsDto>>
{
    public async Task<IReadOnlyCollection<PlaceAnalyticsDto>> Handle(GetEventsPlacesAnalyticsQuery request,
        CancellationToken ct)
    {
        var query = new QueryObject<Event, PlaceCount>(source =>
        {
            if (request.From.HasValue)
                source = source.Where(e => e.CreatedAt >= request.From.Value);

            if (request.To.HasValue)
                source = source.Where(e => e.CreatedAt <= request.To.Value);

            var temp = source
                .Where(e => e.Booking != null)
                .GroupBy(e => e.Booking.PlaceId)
                .OrderByDescending(g => g.Count());

            return (request.Top.HasValue ? temp.Take(request.Top.Value) : temp)
                .Select(g => new PlaceCount(g.Key, g.Count()));
        });

        var analytics = await eventRepository.QueryAsync(query, ct);

        var placesByIdsSpec = new PlacesByIdsSpec(analytics.Select(e => e.PlaceId)).AsNoTracking();
        var places = await placeRepository.ListAsync(placesByIdsSpec, ct);

        var locations = await locationRepository.ListAsync(ct);

        return analytics
            .Join(
                places,
                a => a.PlaceId,
                p => p.Id,
                (a, p) => new { p.LocationId, p.Number, a.Count })
            .Join(
                locations,
                temp => temp.LocationId,
                l => l.Id,
                (temp, l) => new PlaceAnalyticsDto
                {
                    Location = l.Title.Value,
                    Place = temp.Number.Value,
                    Count = temp.Count
                }).ToList();
    }

    private sealed record PlaceCount(int PlaceId, int Count);
}