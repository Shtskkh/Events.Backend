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
        var value = new Text(title).Value;

        if (value.Length > DomainConstraints.Equipment.MaxLength)
            throw new DomainException(DomainErrorMessages.Equipment.GreaterThanMaxLength);

        Value = value;
    }

    public string Value { get; } = null!;

    protected override IEnumerable<object?> GetEqualityComponents()
    {
        yield return Value;
    }
}