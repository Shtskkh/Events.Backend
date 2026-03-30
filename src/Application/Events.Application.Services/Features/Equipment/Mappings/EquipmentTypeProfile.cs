using AutoMapper;
using Events.Contracts.Features.EquipmentTypes;
using Events.Domain.Aggregates.EquipmentAggregate;

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