using System.ComponentModel.DataAnnotations;
using Events.Domain.Shared;

namespace Events.Contracts.Features.Equipment;

/// <summary>
///     Модель создания оборудования.
/// </summary>
public record CreateEquipmentDto
{
    /// <summary>
    ///     Название.
    /// </summary>
    [MaxLength(DomainConstraints.Equipment.MaxLength)]
    public string Title { get; init; } = null!;

    /// <summary>
    ///     Инвентарный номер.
    /// </summary>
    public string InventoryNumber { get; init; } = null!;

    /// <summary>
    ///     ID типа оборудования.
    /// </summary>
    public int EquipmentTypeId { get; init; }

    /// <summary>
    ///     ID помещения для привязки.
    /// </summary>
    public int? PlaceId { get; init; }
}