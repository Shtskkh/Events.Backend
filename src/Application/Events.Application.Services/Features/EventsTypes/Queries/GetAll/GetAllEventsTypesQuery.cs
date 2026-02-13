using Events.Contracts.Features.EventsTypes;
using MediatR;

namespace Events.Application.Services.Features.EventsTypes.Queries.GetAll;

/// <summary>
///     Получить все типы мероприятий.
/// </summary>
public record GetAllEventsTypesQuery : IRequest<IReadOnlyCollection<EventTypeDto>>;