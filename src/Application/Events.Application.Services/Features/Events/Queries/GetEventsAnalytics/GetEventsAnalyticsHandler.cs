using Events.Application.Services.Features.Events.Repositories;
using Events.Application.Services.Features.Events.Specifications;
using Events.Contracts.Events;
using MediatR;

namespace Events.Application.Services.Features.Events.Queries.GetEventsAnalytics;

public class GetEventsAnalyticsHandler(IEventRepository eventRepository)
    : IRequestHandler<GetEventsAnalyticsQuery, EventsAnalyticsDto>
{
    public async Task<EventsAnalyticsDto> Handle(GetEventsAnalyticsQuery request, CancellationToken ct)
    {
        var totalCount = await eventRepository.CountAsync(ct);
        var upcomingCount = await eventRepository.CountAsync(new EventUpcomingSpec(DateTimeOffset.UtcNow), ct);
        var finishedCount = await eventRepository.CountAsync(new EventFinishedSpec(DateTimeOffset.UtcNow), ct);

        return new EventsAnalyticsDto
        {
            TotalCount = totalCount,
            UpcomingCount = upcomingCount,
            FinishedCount = finishedCount
        };
    }
}