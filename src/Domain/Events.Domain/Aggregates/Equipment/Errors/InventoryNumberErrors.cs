using Events.Domain.Aggregates.Equipment.ValueObjects;
using Events.Domain.Shared;

namespace Events.Domain.Aggregates.Equipment.Errors;

public static class InventoryNumberErrors
{
    public static Error GreaterThanMaxLength => new("EquipmentTitle.GreaterThanMaxLength",
        $"Инвентарный номер больше максимальной длины в {InventoryNumber.MaxLength} символ(-ов).");
}