using MediatR;

namespace Events.Application.Services.Features.Events.Commands.Delete;

/// <summary>
///     Удалить мероприятие.
/// </summary>
/// <param name="EventId">Идентификатор мероприятия.</param>
public sealed record DeleteEventQuery(Guid EventId) : IRequest;