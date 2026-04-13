namespace Events.Domain.Aggregates.Equipment.Constraints;

/// <summary>
///     Константы оборудования.
/// </summary>
public static class EquipmentConstraints
{
    public const int MaxLength = 64;

    /// <summary>
    ///     Инвентарный номер.
    /// </summary>
    public static class InventoryNumber
    {
        public const int MaxLength = 16;
    }

    /// <summary>
    ///     Константы типов оборудования.
    /// </summary>
    public static class Type
    {
        public const int MaxLength = 32;
    }
}