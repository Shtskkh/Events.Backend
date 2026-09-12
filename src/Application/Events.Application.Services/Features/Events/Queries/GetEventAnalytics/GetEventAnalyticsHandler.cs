using Events.Application.Services.Features.Analytics.Specifications;
using Events.Application.Services.Features.Events.Repositories;
using Events.Application.Services.Features.Events.Specifications;
using Events.Application.Services.Shared;
using Events.Contracts.Analytics;
using Events.Contracts.Events;
using Events.Domain.Aggregates.Analytics;
using Events.Domain.Aggregates.Events.Errors;
using Events.Domain.Exceptions;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Events.Application.Services.Features.Events.Queries.GetEventAnalytics;

public sealed class GetEventAnalyticsHandler(
    IEventRepository eventRepository,
    IAnalyticsRepository<PageView> pageViewRepository,
    ILogger<GetEventAnalyticsHandler> logger)
    : IRequestHandler<GetEventAnalyticsQuery, EventAnalyticsDto>
{
    public async Task<EventAnalyticsDto> Handle(GetEventAnalyticsQuery request, CancellationToken cancellationToken)
    {
        var eventByIdSpec = new EventByIdSpec(request.EventId).IncludeParticipants().AsNoTracking();
        var @event = await eventRepository.FirstOrDefaultAsync(eventByIdSpec, cancellationToken);

        if (@event == null)
            throw new NotFoundException(EventErrors.NotFoundById(request.EventId));

        List<ViewsDto>? viewsByDay = null;
        long? viewsCount = null;
        try
        {
            var pageViewSpec = new PageViewSpec().WithEntityType(EntityTypes.Event).WithEntityId(request.EventId)
                .AsNoTracking();

            var views = await pageViewRepository.ListAsync(pageViewSpec, cancellationToken);

            viewsCount = views.Count;
            viewsByDay = views
                .GroupBy(v => DateOnly.FromDateTime(v.ViewedAt.Date))
                .Select(g => new ViewsDto
                {
                    Date = g.Key,
                    Views = g.Count()
                })
                .OrderBy(x => x.Date)
                .ToList();
        }
        catch
        {
            logger.LogError("Ошибка получения аналитики для мероприятия с ID: {RequestEventId}.", request.EventId);
        }

        return new EventAnalyticsDto
        {
            Id = @event.Id,
            MaxParticipantsCount = @event.MaxParticipants,
            ParticipantsCount = @event.Participants.Count,
            FinalParticipantsCount = @event.FinalParticipantsCount,
            Views = viewsByDay,
            ViewsCount = viewsCount
        };
    }
}