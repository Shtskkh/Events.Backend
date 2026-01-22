using AutoMapper;
using Events.Contracts.Features.Events.DTOs;
using Events.Domain.Aggregates.EventAggregate;

namespace Events.AppServices.Features.Events.Mappings;

public class EventProfile : Profile
{
    public EventProfile()
    {
        CreateMap<Event, ShortEventDto>()
            .ForMember(dest => dest.Title,
                opt => opt.MapFrom(src => src.Title.Value))
            .ForMember(dest => dest.Announcement,
                opt => opt.MapFrom(src => src.Announcement.Value))
            .ForMember(dest => dest.Description,
                opt => opt.MapFrom(src => src.Description.Value));
    }
}