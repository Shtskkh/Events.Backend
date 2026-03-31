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
        var value = new Text(number).Value;

        if (value.Length > DomainConstraints.Equipment.InventoryNumber.MaxLength)
            throw new DomainException(DomainErrorMessages.Equipment.InventoryNumber.GreaterThanMaxLength);

        Value = value;
    }

    public string Value { get; private set; } = null!;
}