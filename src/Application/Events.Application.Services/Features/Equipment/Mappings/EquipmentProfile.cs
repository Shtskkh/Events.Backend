using AutoMapper;
using Events.Contracts.Equipment;
using Events.Domain.Aggregates.Equipment;

namespace Events.Application.Services.Features.Equipment.Mappings;

public class EquipmentProfile : Profile
{
    public EquipmentProfile()
    {
        CreateMap<EquipmentItem, EquipmentDto>()
            .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.Title.Value))
            .ForMember(dest => dest.InventoryNumber, opt => opt.MapFrom(src => src.InventoryNumber.Value))
            .ForMember(dest => dest.Type, opt => opt.MapFrom(src => src.Type.Title))
            .ForMember(dest => dest.PlaceId, opt => opt.MapFrom(src => src.PlaceId.Value));
    }
}