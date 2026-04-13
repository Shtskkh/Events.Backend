using AutoMapper;
using Events.Application.Services.Features.Analytics.Repositories;
using Events.Application.Services.Features.Analytics.Specifications;
using Events.Application.Services.Features.Events.Repositories;
using Events.Application.Services.Features.Events.Specifications;
using Events.Contracts.Events;
using Events.Domain.Aggregates.AnalyticsAggregate;
using MediatR;

namespace Events.Application.Services.Features.Users.Queries.GetRecentViewedEvents;

/// <inheritdoc />
public sealed class GetRecentViewedEventsHandler(
    IPageViewRepository pageViewRepository,
    IEventRepository eventRepository,
    IMapper mapper)
    : IRequestHandler<GetRecentViewedEventsQuery, IReadOnlyCollection<ShortEventDto>>
{
    /// <inheritdoc />
    public async Task<IReadOnlyCollection<ShortEventDto>> Handle(GetRecentViewedEventsQuery request,
        CancellationToken cancellationToken)
    {
        var userViewsSpec = new PageViewSpec()
            .WithEntityType(EntityTypes.Event)
            .WithUserId(request.UserId)
            .AsNoTracking();

        var userViews = await pageViewRepository.GetByFilterAsync(userViewsSpec, cancellationToken);

        var eventsIds = userViews
            .DistinctBy(v => v.EntityId)
            .Take(10)
            .Select(v => v.EntityId)
            .ToList();

        var eventsSpec = new EventSpec().WithIdList(eventsIds).AsNoTracking();
        var events = await eventRepository.ListAsync(eventsSpec, cancellationToken);

        var eventMap = events.ToDictionary(e => e.Id);
        var orderedEvents = eventsIds
            .Where(eventMap.ContainsKey)
            .Select(id => eventMap[id]);

        return mapper.Map<IReadOnlyCollection<ShortEventDto>>(orderedEvents);
    }
}