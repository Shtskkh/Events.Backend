using System.ComponentModel.DataAnnotations;
using Events.Domain.Aggregates.Equipment.ValueObjects;

namespace Events.Contracts.Equipment;

/// <summary>
///     Форма создания оборудования.
/// </summary>
public sealed record CreateEquipmentDto
{
    /// <summary>
    ///     Название.
    /// </summary>
    [MaxLength(EquipmentTitle.MaxLength)]
    public required string Title { get; init; } = null!;

    /// <summary>
    ///     Инвентарный номер.
    /// </summary>
    [MaxLength(Domain.Aggregates.Equipment.ValueObjects.InventoryNumber.MaxLength)]
    public required string InventoryNumber { get; init; } = null!;

    /// <summary>
    ///     ID типа оборудования.
    /// </summary>
    public required int EquipmentTypeId { get; init; }

    /// <summary>
    ///     ID помещения для привязки (необязательно).
    /// </summary>
    public int? PlaceId { get; init; }
}