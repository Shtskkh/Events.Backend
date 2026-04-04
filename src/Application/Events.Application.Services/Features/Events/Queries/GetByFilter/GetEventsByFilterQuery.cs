using Events.Contracts.Events;
using MediatR;

namespace Events.Application.Services.Features.Events.Queries.GetByFilter;

/// <summary>
///     Запрос для получения мероприятий по фильтру.
/// </summary>
/// <param name="Filter">DTO фильтра.</param>
public sealed record GetEventsByFilterQuery(EventFilterDto Filter) : IRequest<IReadOnlyCollection<ShortEventDto>>;