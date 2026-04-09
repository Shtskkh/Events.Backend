using Events.Contracts.Shared;

namespace Events.Contracts.Equipment;

/// <summary>
///     Модель фильтра оборудования.
/// </summary>
public sealed record EquipmentFilterDto : IPagination
{
    /// <summary>
    ///     Инвентарный номер.
    /// </summary>
    public string? InventoryNumber { get; init; }

    /// <summary>
    ///     Тип оборудования.
    /// </summary>
    public int? EquipmentTypeId { get; init; }

    /// <summary>
    ///     ID помещения.
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