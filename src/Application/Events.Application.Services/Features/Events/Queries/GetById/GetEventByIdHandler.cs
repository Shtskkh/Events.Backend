using AutoMapper;
using Events.Application.Services.Features.Events.Repositories;
using Events.Application.Services.Shared;
using Events.Contracts.Events;
using Events.Contracts.Places;
using Events.Domain.Aggregates.LocationAggregate;
using MediatR;

namespace Events.Application.Services.Features.Events.Queries.GetById;

public sealed class GetEventByIdHandler(
    IEventRepository eventRepository,
    IRepository<Place> placeRepository,
    IMapper mapper)
    : IRequestHandler<GetEventByIdQuery, EventDto>
{
    public async Task<EventDto> Handle(GetEventByIdQuery request, CancellationToken cancellationToken)
    {
        var @event = await eventRepository.GetByIdAsync(request.Id, cancellationToken);
        var dto = mapper.Map<EventDto>(@event);

        if (@event.Booking == null)
            return dto;

        var place = await placeRepository.GetByIdAsync(@event.Booking.PlaceId, cancellationToken);
        dto.PlaceInfo = new BookedPlaceDto
        {
            PlaceId = place.Id,
            Number = place.Number.Value
        };

        return dto;
    }
}