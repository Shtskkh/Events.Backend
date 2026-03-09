using Events.Contracts.Features.Events.DTOs;
using MediatR;

namespace Events.Application.Services.Features.Events.Queries.GetEventsByFilter;

/// <summary>
///     Запрос для получения мероприятий по фильтру.
/// </summary>
/// <param name="Filter">DTO фильтра.</param>
public record GetEventsByFilterQuery(EventFilterDto Filter) : IRequest<IReadOnlyCollection<ShortEventDto>>;