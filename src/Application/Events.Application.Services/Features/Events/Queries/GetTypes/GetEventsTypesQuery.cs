using Events.Contracts.Events.EventsTypes;
using MediatR;

namespace Events.Application.Services.Features.Events.Queries.GetTypes;

/// <summary>
///     Получить все типы мероприятий.
/// </summary>
public record GetEventsTypesQuery : IRequest<IReadOnlyCollection<EventTypeDto>>;