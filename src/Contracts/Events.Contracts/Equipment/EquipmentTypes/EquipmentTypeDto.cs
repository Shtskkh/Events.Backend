namespace Events.Contracts.Equipment.EquipmentTypes;

/// <summary>
///     Тип оборудования.
/// </summary>
public sealed record EquipmentTypeDto
{
    /// <summary>
    ///     Идентификатор.
    /// </summary>
    public int Id { get; init; }

    /// <summary>
    ///     Название.
    /// </summary>
    public string Title { get; init; } = null!;
}