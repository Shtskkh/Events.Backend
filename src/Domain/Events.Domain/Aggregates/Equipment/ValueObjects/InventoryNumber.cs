using Events.Domain.Aggregates.Equipment.Errors;
using Events.Domain.Exceptions;
using Events.Domain.Shared.ValueObjects;

namespace Events.Domain.Aggregates.Equipment.ValueObjects;

/// <summary>
///     Инвентарный номер.
/// </summary>
public class InventoryNumber
{
    public const int MaxLength = 16;

    private InventoryNumber()
    {
    }

    public InventoryNumber(string number)
    {
        Value = new Text(number).Value;

        if (Value.Length > MaxLength)
            throw new DomainException(InventoryNumberErrors.GreaterThanMaxLength);
    }

    public string Value { get; } = null!;
}