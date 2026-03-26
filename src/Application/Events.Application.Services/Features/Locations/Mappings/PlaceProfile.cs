using AutoMapper;
using Events.Contracts.Features.Locations.Places;
using Events.Domain.Aggregates.LocationAggregate;

namespace Events.Application.Services.Features.Locations.Mappings;

/// <inheritdoc />
public class PlaceProfile : Profile
{
    /// <inheritdoc />
    public PlaceProfile()
    {
        CreateMap<Place, ShortPlaceDto>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.Number, opt => opt.MapFrom(src => src.Number.Value))
            .ForMember(dest => dest.Capacity, opt => opt.MapFrom(src => src.Capacity.Value))
            .ForMember(dest => dest.Type, opt => opt.MapFrom(src => src.Type.Title))
            .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.Title.Value));

        CreateMap<Place, PlaceDto>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.Number, opt => opt.MapFrom(src => src.Number.Value))
            .ForMember(dest => dest.Capacity, opt => opt.MapFrom(src => src.Capacity.Value))
            .ForMember(dest => dest.Type, opt => opt.MapFrom(src => src.Type.Title))
            .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.Title.Value));
    }
}