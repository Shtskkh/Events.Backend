using AutoMapper;
using Events.Contracts.Features.Events.DTOs;
using Events.Domain.Aggregates.EventAggregate.Repositories;
using MediatR;

namespace Events.AppServices.Features.Events.Queries.GetById;

public class GetEventByIdHandler(IEventRepository eventRepository, IMapper mapper)
    : IRequestHandler<GetEventByIdQuery, ShortEventDto>
{
    public async Task<ShortEventDto> Handle(GetEventByIdQuery request, CancellationToken cancellationToken)
    {
        var @event = await eventRepository.GetByIdAsync(request.Id);
        return mapper.Map<ShortEventDto>(@event);
    }
}