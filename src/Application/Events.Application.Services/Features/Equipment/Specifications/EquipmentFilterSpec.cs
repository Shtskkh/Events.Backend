using Ardalis.Specification;
using Events.Contracts.Equipment;

namespace Events.Application.Services.Features.Equipment.Specifications;

/// <summary>
///     Спецификация фильтра оборудования.
/// </summary>
public class EquipmentFilterSpec : EquipmentSpec
{
    public EquipmentFilterSpec(EquipmentFilterDto filter)
    {
        if (filter.InventoryNumber != null)
            WithInventoryNumber(filter.InventoryNumber);

        if (filter.EquipmentTypeId.HasValue)
            WithTypeId(filter.EquipmentTypeId.Value);

        if (filter.PlaceId.HasValue)
            WithPlaceId(filter.PlaceId.Value);

        Query.OrderByDescending(e => e.CreatedAt);
        Query.Skip(filter.Size * (filter.Page - 1));
        Query.Take(filter.Size);
    }
}