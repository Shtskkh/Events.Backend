using MediatR;

namespace Events.Application.Services.Features.Events.Commands.DeleteEvent;

/// <summary>
///     Удалить мероприятие.
/// </summary>
/// <param name="EventId">Идентификатор мероприятия.</param>
public record DeleteEventQuery(Guid EventId) : IRequest;