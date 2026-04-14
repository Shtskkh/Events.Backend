using Events.Contracts.Events;
using MediatR;

namespace Events.Application.Services.Features.Events.Queries.GetByFilter;

public sealed record GetEventsByFilterQuery(EventFilterDto Filter) : IRequest<IReadOnlyCollection<ShortEventDto>>;