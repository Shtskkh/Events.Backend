using Ardalis.Specification;
using Events.Domain.Aggregates.Equipment;

namespace Events.Application.Services.Features.Equipment.Specifications;

/// <summary>
///     Базовая спецификация для оборудования.
/// </summary>
public class EquipmentSpec : Specification<EquipmentItem>
{
    public EquipmentSpec WithId(int id)
    {
        Query.Where(e => e.Id == id);
        return this;
    }

    public EquipmentSpec WithInventoryNumber(string inventoryNumber)
    {
        Query.Where(e => e.InventoryNumber.Value == inventoryNumber);
        return this;
    }

    public EquipmentSpec WithTypeId(int typeId)
    {
        Query.Where(e => e.Type.Id == typeId);
        return this;
    }

    public EquipmentSpec WithPlaceId(int placeId)
    {
        Query.Where(e => e.PlaceId == placeId);
        return this;
    }

    public new EquipmentSpec AsNoTracking()
    {
        Query.AsNoTracking();
        return this;
    }
}