using Events.Domain.Aggregates.EquipmentAggregate.Constraints;

namespace Events.Domain.Aggregates.EquipmentAggregate.Errors;

/// <summary>
///     Ошибки оборудования.
/// </summary>
public static class EquipmentErrorMessages
{
    public static readonly string GreaterThanMaxLength =
        $"Длина названия оборудования больше максимальной длины в {EquipmentConstraints.MaxLength} символ(-ов).";

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
        public static readonly string GreaterThanMaxLength =
            $"Длина названия типа оборудования больше максимальной длины в {EquipmentConstraints.Type.MaxLength} символ(-ов).";
    }
}