using Events.Domain.Aggregates.Equipment.Constraints;
using Events.Domain.Aggregates.Equipment.Errors;
using Events.Domain.Exceptions;
using Events.Domain.Shared;
using Events.Domain.Shared.ValueObjects;

namespace Events.Domain.Aggregates.Equipment.ValueObjects;

/// <summary>
///     Название оборудования.
/// </summary>
public class EquipmentTitle : ValueObject
{
    private EquipmentTitle()
    {
    }

    public EquipmentTitle(string title)
    {
        Value = new Text(title).Value;

        if (Value.Length > EquipmentConstraints.MaxLength)
            throw new DomainException(EquipmentErrorMessages.GreaterThanMaxLength);
    }

    public string Value { get; } = null!;

    protected override IEnumerable<object?> GetEqualityComponents()
    {
        yield return Value;
    }
}