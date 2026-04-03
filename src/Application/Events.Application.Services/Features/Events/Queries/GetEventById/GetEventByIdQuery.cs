using Events.Application.Services.Interfaces;
using Events.Contracts.Events;
using Events.Domain.Shared.Entities.Analytics;
using MediatR;

namespace Events.Application.Services.Features.Events.Queries.GetEventById;

/// <summary>
///     Запрос для получения мероприятия по ID.
/// </summary>
/// <param name="Id">Идентификатор мероприятия.</param>
public record GetEventByIdQuery(Guid Id) : IRequest<EventDto>, ITrackPageView
{
    /// <inheritdoc />
    public string EntityType => EntityTypes.Event;

    /// <inheritdoc />
    public Guid EntityId => Id;
}