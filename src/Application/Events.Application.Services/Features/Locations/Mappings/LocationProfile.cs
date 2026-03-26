using AutoMapper;
using Events.Application.Services.Features.Files;
using Events.Contracts.Features.Files;
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
            .ForMember(dest => dest.Address, opt => opt.MapFrom(src => src.Address.Value))
            .ForMember(dest => dest.Preview, opt => opt.MapFrom(src =>
                src.Photos.Count > 0
                    ? new S3FileDto
                    {
                        Bucket = S3Buckets.LocationsPhotos,
                        Key = src.Photos.OrderBy(p => p.Order).First().Filename
                    }
                    : null
            ));

        CreateMap<Location, LocationDto>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.Title.Value))
            .ForMember(dest => dest.Address, opt => opt.MapFrom(src => src.Address.Value));
    }
}