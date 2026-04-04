using AutoMapper;
using Events.Application.Services.Features.Events.Repositories;
using Events.Contracts.Events.EventsTypes;
using MediatR;

namespace Events.Application.Services.Features.Events.Queries.GetTypes;

/// <summary>
///     Handler для получения всех типов мероприятий.
/// </summary>
public sealed class GetEventsTypesHandler(IEventTypeRepository eventTypeRepository, IMapper mapper)
    : IRequestHandler<GetEventsTypesQuery, IReadOnlyCollection<EventTypeDto>>
{
    /// <inheritdoc />
    public async Task<IReadOnlyCollection<EventTypeDto>> Handle(GetEventsTypesQuery request,
        CancellationToken cancellationToken)
    {
        var eventsTypes = await eventTypeRepository.GetAllAsync(cancellationToken);

        return mapper.Map<IReadOnlyCollection<EventTypeDto>>(eventsTypes);
    }
}