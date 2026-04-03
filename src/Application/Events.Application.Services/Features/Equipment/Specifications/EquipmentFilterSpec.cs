using Ardalis.Specification;
using Events.Contracts.Equipment;

namespace Events.Application.Services.Features.Equipment.Specifications;

/// <summary>
///     Спецификация фильтра оборудования.
/// </summary>
public class EquipmentFilterSpec : BaseEquipmentSpec
{
    public EquipmentFilterSpec(EquipmentFilterDto filter)
    {
        if (filter.InventoryNumber != null)
            Query.Where(e => e.InventoryNumber.Value == filter.InventoryNumber);

        if (filter.EquipmentTypeId.HasValue)
            Query.Where(e => e.Type.Id == filter.EquipmentTypeId.Value);

        if (filter.PlaceId.HasValue)
            Query.Where(e => e.PlaceId == filter.PlaceId);

        Query.Skip(filter.Size * (filter.Page - 1));
        Query.Take(filter.Size);
    }
}