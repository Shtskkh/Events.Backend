using System.ComponentModel.DataAnnotations;
using Events.Domain.Aggregates.EquipmentAggregate.Constraints;

namespace Events.Contracts.Equipment;

/// <summary>
///     Модель создания оборудования.
/// </summary>
public record CreateEquipmentDto
{
    /// <summary>
    ///     Название.
    /// </summary>
    [MaxLength(EquipmentConstraints.MaxLength)]
    public required string Title { get; init; } = null!;

    /// <summary>
    ///     Инвентарный номер.
    /// </summary>
    public required string InventoryNumber { get; init; } = null!;

    /// <summary>
    ///     ID типа оборудования.
    /// </summary>
    public required int EquipmentTypeId { get; init; }

    /// <summary>
    ///     ID помещения для привязки.
    /// </summary>
    public int? PlaceId { get; init; }
}