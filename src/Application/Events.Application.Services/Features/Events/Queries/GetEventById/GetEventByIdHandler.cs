using AutoMapper;
using Events.Application.Services.Features.Events.Repositories;
using Events.Contracts.Features.Events.DTOs;
using MediatR;

namespace Events.Application.Services.Features.Events.Queries.GetEventById;

/// <inheritdoc />
public class GetEventByIdHandler(
    IEventRepository eventRepository,
    IMapper mapper)
    : IRequestHandler<GetEventByIdQuery, EventDto>
{
    /// <inheritdoc />
    public async Task<EventDto> Handle(GetEventByIdQuery request, CancellationToken cancellationToken)
    {
        var @event = await eventRepository.GetByIdAsync(request.Id);

        var dto = mapper.Map<EventDto>(@event);

        return dto;
    }
}