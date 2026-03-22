using Events.Contracts.Features.Events.DTOs;
using MediatR;

namespace Events.Application.Services.Features.Users.Queries.GetRecentViewedEvents;

/// <inheritdoc />
public record GetRecentViewedEventsQuery(Guid UserId) : IRequest<IReadOnlyCollection<ShortEventDto>>;