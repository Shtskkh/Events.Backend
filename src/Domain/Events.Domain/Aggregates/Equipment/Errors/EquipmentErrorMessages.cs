using Events.Domain.Aggregates.Equipment.Constraints;

namespace Events.Domain.Aggregates.Equipment.Errors;

/// <summary>
///     Ошибки оборудования.
/// </summary>
public static class EquipmentErrorMessages
{
    public const string NotFoundByFilter = "Оборудование по фильтру не найдено.";

    public static readonly string GreaterThanMaxLength =
        $"Длина названия оборудования больше максимальной длины в {EquipmentConstraints.MaxLength} символ(-ов).";

    public static string NotFoundById(int equipmentItemId)
    {
        return $"Оборудование с ID: {equipmentItemId} не найдено.";
    }

    /// <summary>
    ///     Ошибки инвентарного номера.
    /// </summary>
    public static class InventoryNumber
    {
        public static readonly string GreaterThanMaxLength =
            $"Длина инвентарного номера больше максимальной длины в {EquipmentConstraints.InventoryNumber.MaxLength} символ(-ов).";
    }

    /// <summary>
    ///     Ошибки типа оборудования.
    /// </summary>
    public static class Type
    {
        public const string NotFoundAny = "Типы оборудования не найдены.";

        public static readonly string GreaterThanMaxLength =
            $"Длина названия типа оборудования больше максимальной длины в {EquipmentConstraints.Type.MaxLength} символ(-ов).";

        public static string NotFoundById(int typeId)
        {
            return $"Тип оборудования с ID: {typeId} не найден.";
        }
    }
}