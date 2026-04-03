using Events.Domain.Shared;

namespace Events.Domain.Aggregates.EquipmentAggregate.Errors;

/// <summary>
///     Ошибки оборудования.
/// </summary>
public static class EquipmentErrorMessages
{
    public static readonly string GreaterThanMaxLength =
        $"Длина названия оборудования больше максимальной длины в {DomainConstraints.Equipment.MaxLength} символ(-ов).";

    /// <summary>
    ///     Ошибки инвентарного номера.
    /// </summary>
    public static class InventoryNumber
    {
        public static readonly string GreaterThanMaxLength =
            $"Длина инвентарного номера больше максимальной длины в {DomainConstraints.Equipment.InventoryNumber.MaxLength} символ(-ов).";
    }

    /// <summary>
    ///     Ошибки типа оборудования.
    /// </summary>
    public static class Type
    {
        public static readonly string GreaterThanMaxLength =
            $"Длина названия типа оборудования больше максимальной длины в {DomainConstraints.Equipment.Type.MaxLength} символ(-ов).";
    }
}