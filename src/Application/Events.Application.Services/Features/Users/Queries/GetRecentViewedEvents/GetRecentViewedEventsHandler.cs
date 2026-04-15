using AutoMapper;
using Events.Application.Services.Features.Analytics.Specifications;
using Events.Application.Services.Features.Events.Repositories;
using Events.Application.Services.Features.Events.Specifications;
using Events.Application.Services.Shared;
using Events.Contracts.Events;
using Events.Domain.Aggregates.Analytics;
using Events.Domain.Aggregates.Users.Errors;
using Events.Domain.Exceptions;
using MediatR;

namespace Events.Application.Services.Features.Users.Queries.GetRecentViewedEvents;

public sealed class GetRecentViewedEventsHandler(
    IRepository<PageView> pageViewRepository,
    IEventRepository eventRepository,
    IMapper mapper)
    : IRequestHandler<GetRecentViewedEventsQuery, IReadOnlyCollection<ShortEventDto>>
{
    public async Task<IReadOnlyCollection<ShortEventDto>> Handle(GetRecentViewedEventsQuery request,
        CancellationToken cancellationToken)
    {
        var userViewsSpec = new PageViewSpec()
            .WithEntityType(EntityTypes.Event)
            .WithUserId(request.UserId)
            .AsNoTracking();

        var userViews = await pageViewRepository.ListAsync(userViewsSpec, cancellationToken);

        if (userViews.Count == 0)
            throw new NotFoundException(UserErrors.ViewedEventsNotFoundById(request.UserId));

        var eventsIds = userViews
            .DistinctBy(v => v.EntityId)
            .Take(10)
            .Select(v => v.EntityId)
            .ToList();

        var eventsByIdsSpec = new EventsByIdsSpec(eventsIds).AsNoTracking();
        var events = await eventRepository.ListAsync(eventsByIdsSpec, cancellationToken);

        var eventMap = events.ToDictionary(e => e.Id);
        var orderedEvents = eventsIds
            .Where(eventMap.ContainsKey)
            .Select(id => eventMap[id]);

        return mapper.Map<IReadOnlyCollection<ShortEventDto>>(orderedEvents);
    }
}