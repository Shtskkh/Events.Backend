using Events.Application.Services.Features.Analytics.Specifications;
using Events.Application.Services.Features.Events.Repositories;
using Events.Application.Services.Features.Events.Specifications;
using Events.Application.Services.Shared;
using Events.Contracts.Analytics;
using Events.Contracts.Events;
using Events.Domain.Aggregates.Analytics;
using MediatR;

namespace Events.Application.Services.Features.Events.Queries.GetEventAnalytics;

/// <inheritdoc />
public sealed class GetEventAnalyticsHandler(IEventRepository eventRepository, IRepository<PageView> pageViewRepository)
    : IRequestHandler<GetEventAnalyticsQuery, EventAnalyticsDto>
{
    /// <inheritdoc />
    public async Task<EventAnalyticsDto> Handle(GetEventAnalyticsQuery request, CancellationToken cancellationToken)
    {
        var eventByIdSpec = new EventByIdSpec(request.EventId).IncludeParticipants().AsNoTracking();
        var @event = await eventRepository.FirstOrDefaultAsync(eventByIdSpec, cancellationToken);

        var spec = new PageViewSpec().WithEntityType(EntityTypes.Event).WithEntityId(request.EventId).AsNoTracking();
        var views = await pageViewRepository.ListAsync(spec, cancellationToken);

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