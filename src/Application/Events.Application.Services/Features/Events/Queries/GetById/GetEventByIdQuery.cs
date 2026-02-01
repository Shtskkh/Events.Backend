using Events.Contracts.Features.Events.DTOs;
using MediatR;

namespace Events.Application.Services.Features.Events.Queries.GetById;

/// <summary>
///     Запрос для получения мероприятия по ID.
/// </summary>
/// <param name="Id">Идентификатор мероприятия.</param>
public record GetEventByIdQuery(
    Guid Id
) : IRequest<EventDto>;