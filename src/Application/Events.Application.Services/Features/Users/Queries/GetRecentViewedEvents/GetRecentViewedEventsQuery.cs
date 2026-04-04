using Events.Contracts.Events;
using MediatR;

namespace Events.Application.Services.Features.Users.Queries.GetRecentViewedEvents;

/// <inheritdoc />
public sealed record GetRecentViewedEventsQuery(Guid UserId) : IRequest<IReadOnlyCollection<ShortEventDto>>;