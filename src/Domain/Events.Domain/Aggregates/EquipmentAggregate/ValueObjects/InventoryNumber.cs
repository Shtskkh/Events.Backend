using Events.Domain.Aggregates.EquipmentAggregate.Errors;
using Events.Domain.Exceptions;
using Events.Domain.Shared;
using Events.Domain.Shared.ValueObjects;

namespace Events.Domain.Aggregates.EquipmentAggregate.ValueObjects;

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

        if (Value.Length > DomainConstraints.Equipment.InventoryNumber.MaxLength)
            throw new DomainException(EquipmentErrorMessages.InventoryNumber.GreaterThanMaxLength);
    }

    public string Value { get; } = null!;
}