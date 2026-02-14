using Events.Contracts.Features.EventsTypes;
using MediatR;

namespace Events.Application.Services.Features.Events.Queries.GetAllEventsTypes;

/// <summary>
///     Получить все типы мероприятий.
/// </summary>
public record GetAllEventsTypesQuery : IRequest<IReadOnlyCollection<EventTypeDto>>;