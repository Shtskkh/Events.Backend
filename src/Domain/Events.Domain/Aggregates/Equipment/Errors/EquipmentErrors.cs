using Events.Domain.Shared;

namespace Events.Domain.Aggregates.Equipment.Errors;

public static class EquipmentErrors
{
    public static Error NotFoundByFilter =>
        new("Equipment.NotFoundByFilter", "Оборудование по фильтру не найдено.");

    public static Error NotFoundById(int equipmentItemId)
    {
        return new Error("Equipment.NotFoundById", $"Оборудование с ID: {equipmentItemId} не найдено.");
    }
}