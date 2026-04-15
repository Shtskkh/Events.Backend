using Events.Domain.Aggregates.Equipment.ValueObjects;
using Events.Domain.Shared;

namespace Events.Domain.Aggregates.Equipment.Errors;

public static class EquipmentTitleErrors
{
    public static Error GreaterThanMaxLength =>
        new("EquipmentTitle.GreaterThanMaxLength",
            $"Название оборудование больше максимальной длины в {EquipmentTitle.MaxLength} символ(-ов).");
}