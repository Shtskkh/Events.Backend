using Events.Application.Services.Interfaces;
using Events.Contracts.Events;
using Events.Domain.Aggregates.Analytics;
using MediatR;

namespace Events.Application.Services.Features.Events.Queries.GetById;

public sealed record GetEventByIdQuery(Guid EventId) : IRequest<EventDto>, ITrackPageView
{
    /// <inheritdoc />
    public string EntityType => EntityTypes.Event;

    /// <inheritdoc />
    public Guid EntityId => EventId;
}