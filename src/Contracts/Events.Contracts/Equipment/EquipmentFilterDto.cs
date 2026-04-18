using Events.Contracts.Shared;

namespace Events.Contracts.Equipment;

/// <summary>
///     Форма фильтра оборудования.
/// </summary>
public sealed record EquipmentFilterDto : IPagination
{
    /// <summary>
    ///     Инвентарный номер (необязательно).
    /// </summary>
    public string? InventoryNumber { get; init; }

    /// <summary>
    ///     Тип оборудования (необязательно).
    /// </summary>
    public int? EquipmentTypeId { get; init; }

    /// <summary>
    ///     ID помещения (необязательно).
    /// </summary>
    public int? PlaceId { get; init; }

    /// <summary>
    ///     Размер выборки.
    /// </summary>
    public required int Size { get; init; }

    /// <summary>
    ///     Страница выборки.
    /// </summary>
    public required int Page { get; init; }
}