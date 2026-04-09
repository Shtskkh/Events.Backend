using Events.Application.Services.Features.Analytics.Repositories;
using Events.Application.Services.Features.Events.Repositories;
using Events.Application.Services.Features.Events.Specifications;
using Events.Contracts.Analytics;
using Events.Contracts.Events;
using MediatR;

namespace Events.Application.Services.Features.Events.Queries.GetAnalytics;

/// <inheritdoc />
public sealed class GetEventAnalyticsHandler(IEventRepository eventRepository, IPageViewRepository pageViewRepository)
    : IRequestHandler<GetEventAnalyticsQuery, EventAnalyticsDto>
{
    /// <inheritdoc />
    public async Task<EventAnalyticsDto> Handle(GetEventAnalyticsQuery request, CancellationToken cancellationToken)
    {
        const bool includeParticipants = true;
        var @event = await eventRepository.GetByIdAsync(request.Id, cancellationToken, includeParticipants);

        var spec = new EventViewsSpec(request.Id);

        var views = await pageViewRepository.GetByFilterAsync(spec, cancellationToken);

        var viewsByDay = views
            .GroupBy(v => DateOnly.FromDateTime(v.ViewedAt.Date))
            .Select(g => new ViewsDto
            {
                Date = g.Key,
                Views = g.Count()
            })
            .OrderBy(x => x.Date)
            .ToList();

        return new EventAnalyticsDto
        {
            Id = @event.Id,
            MaxParticipantsCount = @event.MaxParticipants,
            ParticipantsCount = @event.Participants.Count == 0 ? null : @event.Participants.Count,
            ViewsCount = views.Count,
            Views = viewsByDay
        };
    }
}