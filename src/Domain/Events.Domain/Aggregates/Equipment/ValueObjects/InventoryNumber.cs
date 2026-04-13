using Events.Domain.Aggregates.Equipment.Constraints;
using Events.Domain.Aggregates.Equipment.Errors;
using Events.Domain.Exceptions;
using Events.Domain.Shared.ValueObjects;

namespace Events.Domain.Aggregates.Equipment.ValueObjects;

/// <summary>
///     Инвентарный номер.
/// </summary>
public class InventoryNumber
{
    private InventoryNumber()
    {
    }

    public InventoryNumber(string number)
    {
        Value = new Text(number).Value;

        if (Value.Length > EquipmentConstraints.InventoryNumber.MaxLength)
            throw new DomainException(EquipmentErrorMessages.InventoryNumber.GreaterThanMaxLength);
    }

    public string Value { get; } = null!;
}