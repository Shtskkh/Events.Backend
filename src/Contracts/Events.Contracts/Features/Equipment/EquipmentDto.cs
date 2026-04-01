namespace Events.Contracts.Features.Equipment;

/// <summary>
///     Модель оборудования.
/// </summary>
public record EquipmentDto
{
    /// <summary>
    ///     ID.
    /// </summary>
    public int Id { get; init; }

    /// <summary>
    ///     Название.
    /// </summary>
    public string Title { get; init; } = null!;

    /// <summary>
    ///     Инвентарный номер.
    /// </summary>
    public string InventoryNumber { get; init; } = null!;

    /// <summary>
    ///     Тип.
    /// </summary>
    public string Type { get; init; } = null!;

    /// <summary>
    ///     ID помещения.
    /// </summary>
    public int? PlaceId { get; init; }
}