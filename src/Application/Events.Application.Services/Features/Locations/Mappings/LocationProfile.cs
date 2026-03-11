using AutoMapper;
using Events.Contracts.Features.Locations.DTOs;
using Events.Domain.Aggregates.LocationAggregate;

namespace Events.Application.Services.Features.Locations.Mappings;

/// <summary>
///     Профиль маппинга для локаций.
/// </summary>
public class LocationProfile : Profile
{
    /// <inheritdoc />
    public LocationProfile()
    {
        CreateMap<Location, ShortLocationDto>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.Title.Value))
            .ForMember(dest => dest.Address, opt => opt.MapFrom(src => src.Address.Value));

        CreateMap<Location, LocationDto>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.Title.Value))
            .ForMember(dest => dest.Address, opt => opt.MapFrom(src => src.Address.Value));
    }
}