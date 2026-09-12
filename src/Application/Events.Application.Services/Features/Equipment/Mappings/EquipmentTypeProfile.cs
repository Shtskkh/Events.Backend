using AutoMapper;
using Events.Contracts.Equipment.EquipmentTypes;
using Events.Domain.Aggregates.Equipment;

namespace Events.Application.Services.Features.Equipment.Mappings;

/// <summary>
///     Маппинг для типов оборудования.
/// </summary>
public class EquipmentTypeProfile : Profile
{
    public EquipmentTypeProfile()
    {
        CreateMap<EquipmentType, EquipmentTypeDto>();
    }
}