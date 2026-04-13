using AutoMapper;
using Events.Application.Services.Shared;
using Events.Contracts.Events.EventsTypes;
using Events.Domain.Aggregates.EventAggregate;
using MediatR;

namespace Events.Application.Services.Features.Events.Queries.GetTypes;

/// <summary>
///     Handler для получения всех типов мероприятий.
/// </summary>
public sealed class GetEventsTypesHandler(IRepository<EventType> eventTypeRepository, IMapper mapper)
    : IRequestHandler<GetEventsTypesQuery, IReadOnlyCollection<EventTypeDto>>
{
    /// <inheritdoc />
    public async Task<IReadOnlyCollection<EventTypeDto>> Handle(GetEventsTypesQuery request,
        CancellationToken cancellationToken)
    {
        var eventsTypes = await eventTypeRepository.ListAsync(cancellationToken);

        return mapper.Map<IReadOnlyCollection<EventTypeDto>>(eventsTypes);
    }
}