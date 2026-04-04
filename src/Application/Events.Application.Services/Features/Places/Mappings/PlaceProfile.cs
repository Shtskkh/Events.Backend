using AutoMapper;
using Events.Application.Services.Features.Files;
using Events.Contracts.Files;
using Events.Contracts.Places;
using Events.Domain.Aggregates.LocationAggregate;

namespace Events.Application.Services.Features.Places.Mappings;

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
            .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.Title.Value))
            .ForMember(dest => dest.Preview, opt => opt.MapFrom(src =>
                src.Photos.Count > 0
                    ? new S3FileDto
                    {
                        Bucket = S3Buckets.PlacesPhotos,
                        Key = src.Photos.OrderBy(p => p.Order).First().Filename
                    }
                    : null
            ));

        CreateMap<Place, PlaceDto>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.Number, opt => opt.MapFrom(src => src.Number.Value))
            .ForMember(dest => dest.Capacity, opt => opt.MapFrom(src => src.Capacity.Value))
            .ForMember(dest => dest.Type, opt => opt.MapFrom(src => src.Type.Title))
            .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.Title.Value));
    }
}