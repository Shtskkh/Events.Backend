using Events.Domain.Shared;

namespace Events.Domain.Aggregates.Equipment.Errors;

public static class EquipmentTypeErrors
{
    public static Error TitleGreaterThanMaxLength => new("EquipmentType.TitleGreaterThanMaxLength",
        $"Название типа оборудования больше максимальной длины в {EquipmentType.MaxTitleLength} символ(-ов).");

    public static Error NotFoundAny => new("EquipmentType.NotFoundAny", "Типы оборудования не найдены.");

    public static Error NotFoundById(int equipmentTypeId)
    {
        return new Error("EquipmentType.NotFoundById", $"Тип оборудования с ID: {equipmentTypeId} не найден.");
    }
}