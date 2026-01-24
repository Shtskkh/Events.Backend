using AutoMapper;
using Events.Contracts.Features.Events.DTOs;
using Events.Domain.Aggregates.EventAggregate.Repositories;
using MediatR;

namespace Events.Application.Services.Features.Events.Queries.GetById;

public class GetEventByIdHandler(IEventRepository eventRepository, IMapper mapper)
    : IRequestHandler<GetEventByIdQuery, EventDto>
{
    public async Task<EventDto> Handle(GetEventByIdQuery request, CancellationToken cancellationToken)
    {
        var @event = await eventRepository.GetByIdAsync(request.Id);
        return mapper.Map<EventDto>(@event);
    }
}