using Events.Application.Services.Features.Analytics.Repositories;
using Events.Application.Services.Features.Events.Repositories;
using Events.Application.Services.Features.Events.Specifications;
using Events.Contracts.Features.Events.DTOs;
using Events.Contracts.Shared;
using MediatR;

namespace Events.Application.Services.Features.Events.Queries.GetAnalytics;

/// <inheritdoc />
public class GetEventAnalyticHandler(IEventRepository eventRepository, IPageViewRepository pageViewRepository)
    : IRequestHandler<GetEventAnalyticsQuery, EventAnalyticDto>
{
    /// <inheritdoc />
    public async Task<EventAnalyticDto> Handle(GetEventAnalyticsQuery request, CancellationToken cancellationToken)
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

        return new EventAnalyticDto
        {
            Id = @event.Id,
            MaxParticipantsCount = @event.MaxParticipants,
            ParticipantsCount = @event.Participants.Count == 0 ? null : @event.Participants.Count,
            ViewsCount = views.Count,
            Views = viewsByDay
        };
    }
}