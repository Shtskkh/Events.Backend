using AutoMapper;
using Events.Application.Services.Features.Analytics.Repositories;
using Events.Application.Services.Features.Events.Repositories;
using Events.Application.Services.Features.Events.Specifications;
using Events.Application.Services.Features.Users.Specifications;
using Events.Contracts.Features.Events.DTOs;
using MediatR;

namespace Events.Application.Services.Features.Users.Queries.GetRecentViewedEvents;

/// <inheritdoc />
public class GetRecentViewedEventsHandler(
    IPageViewRepository pageViewRepository,
    IEventRepository eventRepository,
    IMapper mapper)
    : IRequestHandler<GetRecentViewedEventsQuery, IReadOnlyCollection<ShortEventDto>>
{
    /// <inheritdoc />
    public async Task<IReadOnlyCollection<ShortEventDto>> Handle(GetRecentViewedEventsQuery request,
        CancellationToken cancellationToken)
    {
        var userViewsSpec = new RecentViewedEventsSpec(request.UserId);
        var userViews = await pageViewRepository.GetByFilterAsync(userViewsSpec, cancellationToken);

        var eventsIds = userViews
            .DistinctBy(v => v.EntityId)
            .Take(10)
            .Select(v => v.EntityId)
            .ToList();

        var eventsSpec = new EventsByIdsSpec(eventsIds);
        var events = await eventRepository.GetByFilterAsync(eventsSpec, cancellationToken);

        var eventMap = events.ToDictionary(e => e.Id);
        var orderedEvents = eventsIds
            .Where(id => eventMap.ContainsKey(id))
            .Select(id => eventMap[id]);

        return mapper.Map<IReadOnlyCollection<ShortEventDto>>(orderedEvents);
    }
}