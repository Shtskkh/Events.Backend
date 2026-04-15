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
    public const int MaxLength = 64;

    private EquipmentTitle()
    {
    }

    public EquipmentTitle(string title)
    {
        Value = new Text(title).Value;

        if (Value.Length > MaxLength)
            throw new DomainException(EquipmentTitleErrors.GreaterThanMaxLength);
    }

    public string Value { get; } = null!;

    protected override IEnumerable<object?> GetEqualityComponents()
    {
        yield return Value;
    }
}