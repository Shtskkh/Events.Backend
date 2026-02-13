using AutoMapper;
using Events.Contracts.Features.EventsTypes;
using Events.Domain.Aggregates.EventAggregate;

namespace Events.Application.Services.Features.EventsTypes.Mappings;

/// <summary>
///     Профили маппинга для типов мероприятий.
/// </summary>
public class EventTypeProfile : Profile
{
    public EventTypeProfile()
    {
        CreateMap<EventType, EventTypeDto>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.Title));
    }
}