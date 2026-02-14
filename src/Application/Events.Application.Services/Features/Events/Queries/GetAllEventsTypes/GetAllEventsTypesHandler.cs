using AutoMapper;
using Events.Application.Services.Features.Events.Repositories;
using Events.Contracts.Features.EventsTypes;
using MediatR;

namespace Events.Application.Services.Features.Events.Queries.GetAllEventsTypes;

/// <summary>
///     Handler для получения всех типов мероприятий.
/// </summary>
public class GetAllEventsTypesHandler(IEventTypeRepository eventTypeRepository, IMapper mapper)
    : IRequestHandler<GetAllEventsTypesQuery, IReadOnlyCollection<EventTypeDto>>
{
    /// <inheritdoc />
    public async Task<IReadOnlyCollection<EventTypeDto>> Handle(GetAllEventsTypesQuery request,
        CancellationToken cancellationToken)
    {
        var eventsTypes = await eventTypeRepository.GetAllAsync();

        return mapper.Map<IReadOnlyCollection<EventTypeDto>>(eventsTypes);
    }
}