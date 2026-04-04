using AutoMapper;
using Events.Application.Services.Features.Events.Repositories;
using Events.Application.Services.Features.Places.Repositories;
using Events.Contracts.Events;
using Events.Contracts.Places;
using MediatR;

namespace Events.Application.Services.Features.Events.Queries.GetById;

/// <inheritdoc />
public sealed class GetEventByIdHandler(
    IEventRepository eventRepository,
    IPlaceRepository placeRepository,
    IMapper mapper)
    : IRequestHandler<GetEventByIdQuery, EventDto>
{
    /// <inheritdoc />
    public async Task<EventDto> Handle(GetEventByIdQuery request, CancellationToken cancellationToken)
    {
        var @event = await eventRepository.GetByIdAsync(request.Id, cancellationToken);
        var dto = mapper.Map<EventDto>(@event);

        if (@event.PlaceId.HasValue)
        {
            var place = await placeRepository.GetById(@event.PlaceId.Value, cancellationToken);

            dto.PlaceInfo = new BookedPlaceDto
            {
                PlaceId = place.Id,
                Number = place.Number.Value
            };
        }

        return dto;
    }
}