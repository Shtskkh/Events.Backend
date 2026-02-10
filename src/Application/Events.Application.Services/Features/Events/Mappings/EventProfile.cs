using AutoMapper;
using Events.Contracts.Features.Events.DTOs;
using Events.Domain.Aggregates.EventAggregate;

namespace Events.Application.Services.Features.Events.Mappings;

/// <summary>
///     Профиль маппинга для мероприятий.
/// </summary>
public class EventProfile : Profile
{
    public EventProfile()
    {
        CreateMap<Event, EventDto>()
            .ForMember(dest => dest.Title,
                opt => opt.MapFrom(src => src.Title.Value))
            .ForMember(dest => dest.Description,
                opt => opt.MapFrom(src => src.Description.Value))
            .ForMember(dest => dest.PreviewDownloadLink, opt => opt.Ignore());

        CreateMap<Event, ShortEventDto>()
            .ForMember(dest => dest.Title,
                opt => opt.MapFrom(src => src.Title.Value))
            .ForMember(dest => dest.Announcement,
                opt => opt.MapFrom(src => src.Announcement.Value));
    }
}