using AutoMapper;
using Events.Application.Services.Features.Events.Repositories;
using Events.Application.Services.Features.Events.Specifications;
using Events.Application.Services.Features.Places.Specifications;
using Events.Application.Services.Shared;
using Events.Contracts.Events;
using Events.Contracts.Places;
using Events.Contracts.Tags;
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
        var eventByIdSpec = new EventByIdSpec(request.EventId).IncludeTags().AsNoTracking();
        var @event = await eventRepository.FirstOrDefaultAsync(eventByIdSpec, cancellationToken);

        if (@event == null)
            throw new NotFoundException(EventErrors.NotFoundById(request.EventId));

        var dto = mapper.Map<EventDto>(@event);

        if (@event.Booking != null)
        {
            var placeByIdSpec = new PlaceByIdSpec(@event.Booking.PlaceId).AsNoTracking();
            var place = await placeRepository.FirstOrDefaultAsync(placeByIdSpec, cancellationToken);

            if (place == null)
                throw new NotFoundException(PlaceErrors.NotFoundById(@event.Booking.PlaceId));

            dto.PlaceInfo = new BookedPlaceDto
            {
                PlaceId = place.Id,
                Number = place.Number.Value
            };
        }

        if (@event.Tags.Count > 0)
            dto.Tags = mapper.Map<List<TagDto>>(@event.Tags);

        return dto;
    }
}