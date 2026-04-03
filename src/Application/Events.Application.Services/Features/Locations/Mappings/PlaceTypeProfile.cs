using AutoMapper;
using Events.Contracts.Places.PlacesTypes;
using Events.Domain.Aggregates.LocationAggregate;

namespace Events.Application.Services.Features.Locations.Mappings;

/// <summary>
///     Профили маппинга для типов помещений.
/// </summary>
public class PlaceTypeProfile : Profile
{
    /// <inheritdoc />
    public PlaceTypeProfile()
    {
        CreateMap<PlaceType, PlaceTypeDto>()
            .ForMember(dest => dest.Id,
                opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.Title,
                opt => opt.MapFrom(src => src.Title));
    }
}