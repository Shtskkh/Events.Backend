using AutoMapper;
using Events.Application.Services.Shared;
using Events.Contracts.Events.EventsTypes;
using Events.Domain.Aggregates.Events;
using Events.Domain.Aggregates.Events.Errors;
using Events.Domain.Exceptions;
using MediatR;

namespace Events.Application.Services.Features.Events.Queries.GetTypes;

public sealed class GetEventsTypesHandler(IRepository<EventType> eventTypeRepository, IMapper mapper)
    : IRequestHandler<GetEventsTypesQuery, IReadOnlyCollection<EventTypeDto>>
{
    public async Task<IReadOnlyCollection<EventTypeDto>> Handle(GetEventsTypesQuery request,
        CancellationToken cancellationToken)
    {
        var eventsTypes = await eventTypeRepository.ListAsync(cancellationToken);

        if (eventsTypes.Count == 0)
            throw new NotFoundException(EventErrorMessages.Type.NotFoundAny);

        return mapper.Map<IReadOnlyCollection<EventTypeDto>>(eventsTypes);
    }
}