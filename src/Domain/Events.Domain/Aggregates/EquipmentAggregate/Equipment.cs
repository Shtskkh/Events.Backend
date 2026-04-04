using Events.Domain.Aggregates.EquipmentAggregate.ValueObjects;
using Events.Domain.Shared;
using Events.Domain.Shared.Interfaces;

namespace Events.Domain.Aggregates.EquipmentAggregate;

/// <summary>
///     Оборудование.
/// </summary>
public class Equipment : Entity<int>, IAggregateRoot, IAuditable
{
    private Equipment()
    {
    }

    public Equipment(int id, EquipmentTitle title, InventoryNumber inventoryNumber, EquipmentType type,
        int? placeId = null) : base(id)
    {
        Title = title;
        InventoryNumber = inventoryNumber;
        Type = type;
        PlaceId = placeId;
        CreatedAt = DateTime.UtcNow;
        UpdatedAt = DateTime.UtcNow;
    }

    /// <summary>
    ///     Название.
    /// </summary>
    public EquipmentTitle Title { get; private set; } = null!;

    /// <summary>
    ///     Инвентарный номер.
    /// </summary>
    public InventoryNumber InventoryNumber { get; private set; } = null!;

    /// <summary>
    ///     Тип.
    /// </summary>
    public EquipmentType Type { get; private set; } = null!;

    /// <summary>
    ///     ID помещения.
    /// </summary>
    public int? PlaceId { get; private set; }

    /// <inheritdoc />
    public DateTime CreatedAt { get; }

    /// <inheritdoc />
    public DateTime UpdatedAt { get; }

    /// <summary>
    ///     Изменить название.
    /// </summary>
    /// <param name="title">Новое название.</param>
    public void ChangeTitle(string title)
    {
        Title = new EquipmentTitle(title);
    }

    /// <summary>
    ///     Изменить инвентарный номер.
    /// </summary>
    /// <param name="inventoryNumber">Новый номер.</param>
    public void ChangeInventoryNumber(string inventoryNumber)
    {
        InventoryNumber = new InventoryNumber(inventoryNumber);
    }

    /// <summary>
    ///     Изменить тип.
    /// </summary>
    /// <param name="type">Новый тип.</param>
    public void ChangeType(EquipmentType type)
    {
        Type = type;
    }

    /// <summary>
    ///     Привязать к помещению.
    /// </summary>
    /// <param name="placeId">ID помещения.</param>
    public void BindToPlace(int placeId)
    {
        PlaceId = placeId;
    }

    /// <summary>
    ///     Отвязать от помещения.
    /// </summary>
    public void UnbindFronPlace()
    {
        PlaceId = null;
    }
}