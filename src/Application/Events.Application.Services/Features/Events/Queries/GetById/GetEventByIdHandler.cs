using AutoMapper;
using Events.Application.Services.Features.Events.Repositories;
using Events.Application.Services.Shared;
using Events.Contracts.Events;
using Events.Contracts.Places;
using Events.Domain.Aggregates.Events.Errors;
using Events.Domain.Aggregates.Locations;
using Events.Domain.Aggregates.Locations.Errors;
using Events.Domain.Exceptions;
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
        var @event = await eventRepository.GetByIdAsync(request.EventId, cancellationToken);

        if (@event == null)
            throw new NotFoundException(EventErrorMessages.NotFoundById(request.EventId));

        var dto = mapper.Map<EventDto>(@event);

        if (@event.Booking == null)
            return dto;

        var place = await placeRepository.GetByIdAsync(@event.Booking.PlaceId, cancellationToken);

        if (place == null)
            throw new NotFoundException(PlaceErrorMessages.NotFoundById(@event.Booking.PlaceId));

        dto.PlaceInfo = new BookedPlaceDto
        {
            PlaceId = place.Id,
            Number = place.Number.Value
        };

        return dto;
    }
}