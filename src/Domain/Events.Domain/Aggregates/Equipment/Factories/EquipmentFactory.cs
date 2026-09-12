using Events.Domain.Aggregates.Equipment.ValueObjects;

namespace Events.Domain.Aggregates.Equipment.Factories;

/// <summary>
///     Фабрика оборудования.
/// </summary>
public static class EquipmentFactory
{
    public static EquipmentItem Create(string title, string inventoryNumber, EquipmentType type, int? placeId = null)
    {
        var titleVo = new EquipmentTitle(title);
        var numberVo = new InventoryNumber(inventoryNumber);

        return new EquipmentItem(default, titleVo, numberVo, type, placeId);
    }
}